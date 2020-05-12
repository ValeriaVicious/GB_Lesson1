using MyFirstWPFapp.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWPFapp.ViewModel
{
    class MainWindowViewModel: ViewModelBase
    {
        private string _Title = "Редактор работников и департаментов";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
