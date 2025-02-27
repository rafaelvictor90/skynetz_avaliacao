using Skynetz.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Skynetz.WebUI
{
    public partial class FaleMais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PlanFaleMaisService planFaleMaisService = new PlanFaleMaisService();

            GridFaleMais.DataSource = planFaleMaisService.GetPlanFaleMais().Select(
                p => new
                {
                    ID = p.Id,
                    TEMPO = p.MinuteTime,
                    PLANO = p.Name
                });
            GridFaleMais.DataBind();
        }
    }
}