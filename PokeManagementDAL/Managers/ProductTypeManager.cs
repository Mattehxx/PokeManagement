﻿using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public class ProductTypeManager(PokeDbContext ctx) : GenericManager<ProductType>(ctx),IProductTypeManager
    {
    }
}
