﻿using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Connections
{
    public interface IDbConnectionStrategy
    {
        string GetConnectionString();
    }
}
