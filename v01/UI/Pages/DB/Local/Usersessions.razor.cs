using Models.DB.Local;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DB.Local
{
    public class UsersessionsBase : ComponentBase
    {
        protected IList<Models.DB.Local.Usersessions> usersessions = null;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                //usersessions = await GetUsersessionsAsync();
            }
            catch (Exception ae)
            {
                ae.Message.ToString();
                if (ae.InnerException != null) _ = ae.InnerException.Message.ToString();
            }
            return;
        }
    }
}
