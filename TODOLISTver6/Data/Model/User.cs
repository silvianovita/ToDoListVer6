using Data.Base;
using Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class User :BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public User() { }
        public User(UserVM userVM)
        {
            this.UserName = userVM.UserName;
            this.Password = userVM.Password;
            this.IsDelete = false;
            this.CreateDate = DateTimeOffset.Now;
        }
        public void Update(UserVM userVM)
        {
            this.UserName = userVM.UserName;
            this.Password = userVM.Password;
            this.UpdateDate = DateTimeOffset.Now;
        }
        public void Delete(UserVM userVM)
        {
            this.IsDelete = true;
            this.DeleteDate = DateTimeOffset.Now;
        }
    }
}
