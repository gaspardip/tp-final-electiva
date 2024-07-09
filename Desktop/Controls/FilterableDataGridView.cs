﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controls
{
    public class FilterableDataGridView<T> : UserControl
    {
        public delegate void ActionHandler(T entity);

        private readonly List<ButtonDetails> _customButtons = new List<ButtonDetails>();
        private BindingSource _bindingSource;
        private DataGridView _dataGridView;
        private List<T> _dataSource;
        private List<string> _displayProperties;
        private TextBox _textBoxFilter;

        public FilterableDataGridView()
        {
            InitializeComponents();
        }

        public List<string> DisplayProperties
        {
            get => _displayProperties;
            set
            {
                _displayProperties = value;
                RefreshDataSource();
            }
        }

        public Func<List<T>> DataFetcher { get; set; }

        public List<T> DataSource
        {
            get => _dataSource;
            private set
            {
                _dataSource = value;
                _bindingSource.DataSource = ConvertToDataTable(_dataSource);
                _dataGridView.DataSource = _bindingSource;
                SetupDataGridView();
            }
        }

        private void InitializeComponents()
        {
            _dataGridView = new DataGridView { Dock = DockStyle.Fill };
            _textBoxFilter = new TextBox { Dock = DockStyle.Top };
            _bindingSource = new BindingSource();

            _dataGridView.AllowUserToAddRows = false;
            _dataGridView.AllowUserToDeleteRows = false;
            _dataGridView.AllowUserToOrderColumns = false;
            _dataGridView.AllowUserToResizeColumns = false;
            _dataGridView.AllowUserToResizeRows = false;
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridView.ReadOnly = true;
            _dataGridView.MultiSelect = false;
            _dataGridView.RowHeadersVisible = false;

            _dataGridView.CellClick += DataGridView_CellClick;
            _dataGridView.DataBindingComplete += (sender, e) => SetColumnDisplayOrder();

            _textBoxFilter.TextChanged += TextBoxFilter_TextChanged;

            Controls.Add(_dataGridView);
            Controls.Add(_textBoxFilter);
        }

        private void SetupDataGridView()
        {
            if (_displayProperties == null || _dataSource == null) return;

            _dataGridView.Columns.Clear();

            // Add columns based on display properties
            foreach (var prop in _displayProperties)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    DataPropertyName = prop,
                    HeaderText = prop,
                    Name = prop
                };

                _dataGridView.Columns.Add(column);
            }

            // Add custom button columns
            foreach (var button in _customButtons)
            {
                var buttonColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "",
                    Name = button.Name,
                    Text = button.Text,
                    UseColumnTextForButtonValue = true
                };

                _dataGridView.Columns.Add(buttonColumn);
            }

            ApplyColumnFormatting();
        }

        private void SetColumnDisplayOrder()
        {
            var dataIndex = 0;

            // Ensure the data source columns are displayed first
            foreach (var prop in _displayProperties.Where(prop => _dataGridView.Columns.Contains(prop)))
            {
                _dataGridView.Columns[prop].DisplayIndex = dataIndex++;
            }

            // Set the display indices for custom buttons if they exist
            foreach (var button in _customButtons.Where(button => _dataGridView.Columns.Contains(button.Name)))
            {
                _dataGridView.Columns[button.Name].DisplayIndex = dataIndex++;
            }
        }

        private void ApplyColumnFormatting()
        {
            foreach (DataGridViewColumn column in _dataGridView.Columns)
            {
                if (column.ValueType != typeof(decimal) && column.ValueType != typeof(double) &&
                    column.ValueType != typeof(float)) continue;

                column.DefaultCellStyle.Format = "C2";
                column.DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("es-AR");
            }
        }

        public void AddEditButton(ActionHandler handler, string text = "Editar")
        {
            AddCustomButton(text, handler);
        }

        public void AddDeleteButton(ActionHandler handler, string text = "Eliminar")
        {
            AddCustomButton(text, handler);
        }

        public void AddCustomButton(string buttonText, ActionHandler handler)
        {
            var buttonName = Guid.NewGuid().ToString();

            _customButtons.Add(new ButtonDetails { Text = buttonText, Name = buttonName, Handler = handler });

            SetupDataGridView();
        }

        private void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_textBoxFilter.Text))
            {
                _bindingSource.Filter = string.Empty;
            }
            else
            {
                var filter = new StringBuilder();
                var safeFilterText = _textBoxFilter.Text.Replace("'", "''");

                var isFirst = true;

                foreach (DataGridViewColumn col in _dataGridView.Columns)
                {
                    if (col.ValueType != typeof(string) && col.ValueType != typeof(int) &&
                        col.ValueType != typeof(decimal) && col.ValueType != typeof(DateTime))
                    {
                        continue;
                    }

                    if (!isFirst)
                    {
                        filter.Append(" OR ");
                    }

                    filter.Append($"Convert([{col.Name}], 'System.String') LIKE '%{safeFilterText}%'");
                    isFirst = false;
                }

                _bindingSource.Filter = filter.ToString();
            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var entity = _dataSource[e.RowIndex];

            foreach (var button in _customButtons.Where(button =>
                         e.ColumnIndex == _dataGridView.Columns[button.Name].Index))
            {
                button.Handler?.Invoke(entity);
                RefreshDataSource();
                return;
            }
        }

        public void RefreshDataSource()
        {
            if (DataFetcher != null)
            {
                DataSource = DataFetcher();
            }
        }

        private DataTable ConvertToDataTable(List<T> data)
        {
            var dataTable = new DataTable();

            // Get the properties of the type T
            var properties = typeof(T).GetProperties()
                .Where(p => _displayProperties == null || _displayProperties.Contains(p.Name))
                .ToArray();

            // Add columns to the DataTable with the appropriate type
            foreach (var prop in properties)
            {
                var propType = prop.PropertyType;

                // Check if the property is nullable and use the underlying type if it is
                if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propType = Nullable.GetUnderlyingType(propType);
                }

                dataTable.Columns.Add(prop.Name, propType);
            }

            // Add rows to the DataTable
            foreach (var item in data)
            {
                var values = new object[properties.Length];
                for (var i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(item) ?? DBNull.Value;
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        private class ButtonDetails
        {
            public string Name { get; set; }
            public string Text { get; set; }
            public ActionHandler Handler { get; set; }
        }
    }
}