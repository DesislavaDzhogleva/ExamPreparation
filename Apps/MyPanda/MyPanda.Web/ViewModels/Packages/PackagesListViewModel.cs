using System;
using System.Collections.Generic;
using System.Text;

namespace MyPanda.Web.ViewModels.Packages
{
    public class PackagesListViewModel
    {
        public IEnumerable<PackageViewModel> Packages { get; set; }
    }
}
