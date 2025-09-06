namespace THosCase.Business.ViewModel
{
    using System.Collections.Generic;

    /// <summary>
    /// User View Model
    /// </summary>
    public class UserViewModel
    {
        /// <summary>
        /// Users
        /// </summary>
        public List<UserModel> Users { get; set; }

        /// <summary>
        /// Page Title
        /// </summary>
        public string PageTitle { get; set; }
    }
}
