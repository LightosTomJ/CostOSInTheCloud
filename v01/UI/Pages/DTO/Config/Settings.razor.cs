using DevExpress.Blazor;
using Models.DTO.Config;
using Microsoft.AspNetCore.Blazor.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Radzen;

namespace UI.Pages.DTO.Config
{
    public class SettingsBase : ComponentBase
    {
        //Tab collection
        protected int activeTabIndex = 1;
        protected int ActiveTabIndex
        {
            get => activeTabIndex;
            set { activeTabIndex = value; InvokeAsync(StateHasChanged); }
        }
    }
}
