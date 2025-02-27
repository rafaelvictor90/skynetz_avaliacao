using Skynetz.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Skynetz.WebUI
{
    public partial class Taxas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FlatRateService flatRateService = new FlatRateService();

            GridTaxas.DataSource = flatRateService.GetFlatRates().Select(
                f => new
                {
                    ID = f.Id,
                    ORIGEM = f.Origin,
                    DESTINO = f.Destiny,
                    PREÇO = f.MinuteValue
                });
            GridTaxas.DataBind();
        }
    }
}