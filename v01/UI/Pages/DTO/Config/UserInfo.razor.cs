using API.Controllers.DB.Config;
using Microsoft.AspNetCore.Components;
using Models.DB.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Pages.DTO.Config
{
    public class UserInfoBase : ComponentBase
    {
        private List<AspNetUsers> users = null;
        //private List<Companies> companies = null;
        protected List<Genders> genders = null;
        protected Companies company = null;
        protected AspNetUsers user = null;
        protected Genders selectedGender  {
            get => user.Gender;
            set
            {
                selectedGender = value;
                InvokeAsync(StateHasChanged);
                user.Gender = selectedGender;
            } 
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                configContext configC = new configContext();

                //Get users
                AspNetUsersController uc = new AspNetUsersController(configC);
                users = await uc.GetAspNetUsers();

                //Get Companies
                CompaniesController cc = new CompaniesController(configC);

                //Get genders
                GendersController gc = new GendersController(configC);
                genders = await gc.GetGenders();


                if (users.Count > 0)
                {
                    user = users[0];
                    if (user.CompanyId != null) user.Company = await cc.GetCompanyById((int)user.CompanyId);
                    if (user.GenderId != null) user.Gender = await gc.GetGender((byte)user.GenderId);
                }
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
