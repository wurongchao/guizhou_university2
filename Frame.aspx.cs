﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GZDXCC.Admin
{
    public partial class Frame :LoginValidate
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckValid();
        }
    }
}