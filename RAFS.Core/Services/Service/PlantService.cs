using AutoMapper;
using Azure;
using Microsoft.EntityFrameworkCore;
using RAFS.Core.DTO;
using RAFS.Core.Models;
using RAFS.Core.Repositories.Generics;
using RAFS.Core.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAFS.Core.Services.Service
{
    public class PlantService : IPlantService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PlantService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public bool CreatePlant(Plant milestone)
        {


            try
            {
                

                int plantid = _uow.plantRepo.CreatePlant(milestone);
                _uow.Save();


                Diary diary = new Diary();
                diary.PlantId = plantid;
                diary.Title = milestone.Name + " đã được tạo";
                diary.Type = 4;
                diary.Body = "Trồng cây";
                diary.CreatedDay = DateTime.Now;
                diary.LastUpdate = DateTime.Now;
                diary.Image = "no much";
                diary.Status = true;
                _uow.diaryRepo.Add(diary);
                _uow.Save();

                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeletePlant(int milestoneId)
        {
            try
            {
                Plant plant = this.GetPlantById(milestoneId);
                Diary diary = new Diary();
                diary.PlantId = milestoneId;
                diary.Title = plant.Name + " đã bị hủy";
                diary.Type = 5;
                diary.Body = "Hủy cây";
                diary.CreatedDay = DateTime.Now;
                diary.LastUpdate = DateTime.Now;
                diary.Image = "no much";
                diary.Status = true;
                _uow.diaryRepo.Add(diary);
                _uow.Save();

                _uow.plantRepo.DeletePlant(milestoneId);
                _uow.Save();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Plant> GetAllFarmPlant(int farmid)
        {
            List<Milestone> milestones1 = _uow.milestonRepo.GetMilestones(farmid);
            List<Plant> milestones = _uow.plantRepo.GetPlants();
            List<Plant> result = new List<Plant>();
            foreach(Milestone milestone in milestones1)
            {
                List<Plant> temp = milestones.Where(x => x.MilestoneId == milestone.Id).ToList();
                foreach(var plant in temp)
                {
                    result.Add(plant);
                }
            }



            return result; 
        }
        public bool CheckArea(int farmid, int area, string unitName)
        {
            
            List<Plant> milestones = GetAllFarmPlant(farmid);
            Farm farm = _uow.plantRepo.GetFarm(farmid);
            bool result = true ;

            double farmArea = farm.Area * 10000;
            double usedArea = 0;

            foreach(var milestone in milestones)
            {
                if (milestone.AreaUnit.ToLower().Equals("m2".ToLower()))
                {
                    usedArea += milestone.Area;
                }
                if (milestone.AreaUnit.ToLower().Equals("ha".ToLower()))
                {
                    usedArea += milestone.Area * 10000;
                }
                if (milestone.AreaUnit.ToLower().Equals("km2".ToLower()))
                {
                    usedArea += milestone.Area * 1000000;
                }

            }
            if (unitName.ToLower().Equals("m2".ToLower()))
            {
                usedArea += area;
            }
            if (unitName.ToLower().Equals("ha".ToLower()))
            {
                usedArea += area * 10000;
            }
            if (unitName.ToLower().Equals("km2".ToLower()))
            {
                usedArea += area * 1000000;
            }
            if(usedArea > farmArea)
            {
                result = false;
            }

            return result;
        }
        public bool CheckAreaUpdate(int farmid, int area, string unitName,int plantid)
        {

            List<Plant> milestones = GetAllFarmPlant(farmid);
            Farm farm = _uow.plantRepo.GetFarm(farmid);
            bool result = true;

            double farmArea = farm.Area * 10000;
            double usedArea = 0;

            foreach (var milestone in milestones)
            {
                if(milestone.Id != plantid) { 
                    if (milestone.AreaUnit.ToLower().Equals("m2".ToLower()))
                    {
                        usedArea += milestone.Area;
                    }
                    if (milestone.AreaUnit.ToLower().Equals("ha".ToLower()))
                    {
                        usedArea += milestone.Area * 10000;
                    }
                    if (milestone.AreaUnit.ToLower().Equals("km2".ToLower()))
                    {
                        usedArea += milestone.Area * 1000000;
                    }
                }

            }
            if (unitName.ToLower().Equals("m2".ToLower()))
            {
                usedArea += area;
            }
            if (unitName.ToLower().Equals("ha".ToLower()))
            {
                usedArea += area * 10000;
            }
            if (unitName.ToLower().Equals("km2".ToLower()))
            {
                usedArea += area * 1000000;
            }

            if (usedArea > farmArea)
            {
                result = false;
            }

            return result;
        }
        public List<PlantRecordDTO> GetAllPlantRecord(int plantid)
        {
            List<PlantRecordDTO> milestones = _uow.plantRepo.GetPlantDiaries(plantid);


            return milestones;
        }

     

        public Plant GetPlantById(int milestoneId)
        {
            Plant milestones = _uow.plantRepo.GetPlantById(milestoneId);
            

            return milestones; 
        }

        public bool UpdatePlant(Plant milestone)
        {
            try
            {
                
                _uow.plantRepo.UpdatePlant(milestone);
                _uow.Save();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
