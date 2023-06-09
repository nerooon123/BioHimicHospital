﻿using BioHimicHospital.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioHimicHospital.Controllers
{
    
    public class LaboratoryAssistantsController
    {

        
        /// <summary>
        /// ID Биологического Иследование
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BiomaterialResearch GetBiomateriaResearchId(int id)
        {
            Core db = new Core();
            return db.context.BiomaterialResearch.FirstOrDefault(p => p.IdBiomaterialResearch == id);
        }
    }
}
