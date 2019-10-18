using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfDemo.ViewModel.Common;

namespace WpfDemo.ViewModel.Login
{
    public class LoginViewModel : NotificationObject
    {
        public LoginViewModel()
        {
            obj.UserName = "test";
        }

        /// <summary>
        /// Model对象
        /// </summary>
        private LoginModel obj = new LoginModel();

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            get
            {
                return obj.UserName;
            }
            set
            {
                obj.UserName = value;
                this.RaisePropertyChanged("UserName");
            }
        }
    }

}
