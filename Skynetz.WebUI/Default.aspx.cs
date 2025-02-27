using Skynetz.Application.DTOs;
using Skynetz.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Skynetz.WebUI
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FlatRateService flatRateService = new FlatRateService();
            var flatRates = flatRateService.GetFlatRates();

            DropDownOrigin.DataSource = flatRates.Select(f => f.Origin).Distinct();
            DropDownOrigin.DataBind();

            DropDownDestiny.DataSource = flatRates.Select(f => f.Destiny).Distinct();
            DropDownDestiny.DataBind();

            PlanFaleMaisService planFaleMaisService = new PlanFaleMaisService();
            var planFaleMais = planFaleMaisService.GetPlanFaleMais();

            DropDownFaleMais.DataValueField = "Id";
            DropDownFaleMais.DataTextField = "Name";
            DropDownFaleMais.DataSource = planFaleMais.Select(
                p => new
                {
                    Id = p.Id,
                    Name = p.Name
                });
            DropDownFaleMais.DataBind();
        }

        [WebMethod]
        public static IEnumerable<PlanFaleMaisDTO> GetPlanFaleMaisSearch(string origin, string destiny, string idPlan, string minutes)
        {
            PlanFaleMaisService planFaleMaisService = new PlanFaleMaisService();

            if (!string.IsNullOrEmpty(origin) &&
                !string.IsNullOrEmpty(destiny) &&
                !string.IsNullOrEmpty(idPlan) &&
                !string.IsNullOrEmpty(minutes))
            {
                int planFaleMais = Convert.ToInt32(idPlan);
                int minutesTemp = Convert.ToInt32(minutes);
                var faleMaisList = planFaleMaisService.GetBySearch(origin, destiny, minutesTemp, planFaleMais);
                return faleMaisList;
            }

            return null;
        }

    }
}