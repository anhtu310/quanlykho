using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using QuanLyKho.Models;

namespace QuanLyKho.Views
{
    public partial class InputInfoForm : UserControl
    {
        private QuanlyKhoDbContext _context;
        private InputInfo _inputInfo;  // Để lưu trữ thông tin chỉnh sửa hoặc thêm mới
        private int _inputId;  // Lưu trữ IdInput

        public Action OnInputInfoUpdated { get; set; }

        public InputInfoForm(int inputId)
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            _inputId = inputId;
            LoadData();
        }

        private void LoadData()
        {
            // Tải danh sách sản phẩm và nhà cung cấp vào ComboBox
            ProductComboBox.ItemsSource = _context.Products.ToList();
            SupplierComboBox.ItemsSource = _context.Suppliers.ToList();
        }

        public InputInfoForm(InputInfo inputInfo)
        {
            InitializeComponent();
            _context = new QuanlyKhoDbContext();
            _inputInfo = inputInfo;
            PopulateFields();
        }

        private void PopulateFields()
        {
            if (_inputInfo != null)
            {
                ProductComboBox.SelectedValue = _inputInfo.IdProduct;
                SupplierComboBox.SelectedValue = _inputInfo.IdSupplier;
                CountTextBox.Text = _inputInfo.Count.ToString();
                InputPriceTextBox.Text = _inputInfo.InputPrice.ToString();
                OutputPriceTextBox.Text = _inputInfo.OutputPrice.ToString();
                StatusComboBox.SelectedItem = StatusComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(i => i.Content.ToString() == _inputInfo.Status);
            }
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Kiểm tra dữ liệu nhập vào trước khi lưu
                if (string.IsNullOrEmpty(CountTextBox.Text) || string.IsNullOrEmpty(InputPriceTextBox.Text) || string.IsNullOrEmpty(OutputPriceTextBox.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Lấy giá trị từ các control
                var productId = (int)ProductComboBox.SelectedValue;
                var supplierId = (int)SupplierComboBox.SelectedValue;
                var count = int.Parse(CountTextBox.Text);
                var inputPrice = decimal.Parse(InputPriceTextBox.Text);
                var outputPrice = decimal.Parse(OutputPriceTextBox.Text);
                var status = ((ComboBoxItem)StatusComboBox.SelectedItem).Content.ToString();

                // Thêm mới hoặc chỉnh sửa đối tượng InputInfo
                if (_inputInfo == null)
                {
                    _inputInfo = new InputInfo
                    {
                        IdProduct = productId,
                        IdSupplier = supplierId,
                        Count = count,
                        InputPrice = inputPrice,
                        OutputPrice = outputPrice,
                        Status = status
                    };
                    _context.InputInfos.Add(_inputInfo);
                }
                else
                {
                    _inputInfo.IdProduct = productId;
                    _inputInfo.IdSupplier = supplierId;
                    _inputInfo.Count = count;
                    _inputInfo.InputPrice = inputPrice;
                    _inputInfo.OutputPrice = outputPrice;
                    _inputInfo.Status = status;
                }

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();

                // Gọi phương thức để cập nhật lại giao diện chính
                OnInputInfoUpdated?.Invoke();

                // Thông báo thành công
                MessageBox.Show("Lưu thông tin thành công!", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Close();
        }
    }
}
