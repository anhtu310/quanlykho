    using System;
    using System.Collections.Generic;
using QuanLyKho.Helpers;
using System.Windows.Media;

    namespace QuanLyKho.Models;

    public partial class InputInfo
    {
        public int Id { get; set; }

        public int IdProductSupplier { get; set; }

        public int IdInput { get; set; }

        public int Count { get; set; }

        public decimal InputPrice { get; set; }

        public decimal OutputPrice { get; set; }

        public string? Status { get; set; }

        public byte[]? ContractImage { get; set; }

    public ImageSource ImageSource
    {
        get
        {
            return ImageHelper.ConvertToImageSource(ContractImage);
        }
    }

    public virtual Input IdInputNavigation { get; set; } = null!;

        public virtual ProductSupplier IdProductSupplierNavigation { get; set; } = null!;

        public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
    }
