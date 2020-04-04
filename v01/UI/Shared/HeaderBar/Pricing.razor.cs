using Microsoft.AspNetCore.Components;
using Models.DTO.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace UI.Shared.HeaderBar
{
    public class PricingBase : ComponentBase
    {
        protected List<PurchasePackage> packages = null;
        protected override void OnInitialized()
        {
            try
            {
                packages = GetPackages();
            }
            catch (Exception ae)
            {
                ae.Message.ToString();
                if (ae.InnerException != null) _ = ae.InnerException.Message.ToString();
            }
            return;
        }

        private List<PurchasePackage> GetPackages()
        {
            List<PurchasePackage> lP = new List<PurchasePackage>();

            lP.Add(new PurchasePackage()
            {
                Name = "Basic",
                Cost = 15,
                Max_Projects = "5",
                Max_Project_Size = "1 Gb",
                Rendering_Resource = "Local",
                Rate_Libraries = "Excluded",
                Data_Feeds = "Excluded",
                Escalation = "Excluded",
                Advanced_WBS = "Excluded"
            });

            lP.Add(new PurchasePackage()
            {
                Name = "Intermediate",
                Cost = 30,
                Max_Projects = "20",
                Max_Project_Size = "2 Gb",
                Rendering_Resource = "Local",
                Rate_Libraries = "Included",
                Data_Feeds = "Included",
                Escalation = "Included",
                Advanced_WBS = "Included"
            });

            lP.Add(new PurchasePackage()
            {
                Name = "Advanced",
                Cost = 50,
                Max_Projects = "300",
                Max_Project_Size = "2 Gb",
                Rendering_Resource = "Local",
                Rate_Libraries = "Excluded",
                Data_Feeds = "Excluded",
                Escalation = "Excluded",
                Advanced_WBS = "Excluded"
            });

            lP.Add(new PurchasePackage()
            {
                Name = "Pro",
                Cost = 90,
                Max_Projects = "Unlimited",
                Max_Project_Size = "5 Gb",
                Rendering_Resource = "Cloud",
                Rate_Libraries = "Included",
                Data_Feeds = "Included",
                Escalation = "Included",
                Advanced_WBS = "Included"
            });

            lP.Add(new PurchasePackage()
            {
                Name = "Enterprise",
                Cost = 900,
                Max_Projects = "Unlimited",
                Max_Project_Size = "Unlimited",
                Rendering_Resource = "Cloud",
                Rate_Libraries = "Included",
                Data_Feeds = "Included",
                Escalation = "Included",
                Advanced_WBS = "Included"
            });

            return lP;
        }
    }
}
