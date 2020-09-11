using Estimationtool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimationTool.Models
{
    public class FilterObj: BaseViewModel
    {
        private bool _Is_Checked;
        private string _Title;


      
        public bool Is_Check
        {
            get { return this._Is_Checked; }
            set { this.SetProperty(ref this._Is_Checked, value); }
        }

        public string Title
        {
            get { return this._Title; }
            set { this.SetProperty(ref this._Title, value); }
        }



    }
}
