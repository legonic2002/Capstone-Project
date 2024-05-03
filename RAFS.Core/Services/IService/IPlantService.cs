using RAFS.Core.DTO;
using RAFS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAFS.Core.Services.IService
{
    public interface IPlantService
    {
        public bool CheckArea(int farmid, int area, string unitName);
        public bool CheckAreaUpdate(int farmid, int area, string unitName, int plantid);
        public List<Plant> GetAllFarmPlant(int farmid);
        public List<PlantRecordDTO> GetAllPlantRecord(int plantid);
        public Plant GetPlantById(int milestoneId);
        public bool CreatePlant(Plant milestone);
        public bool UpdatePlant(Plant milestone);
        public bool DeletePlant(int milestoneId);
       
    }
   
}
