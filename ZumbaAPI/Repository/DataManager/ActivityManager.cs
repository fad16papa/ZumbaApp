using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZumbaAPI.DBContext;
using ZumbaAPI.Repository.Interface;
using ZumbaModels.Models;
using ZumbaModels.Models.ApiResponse;

namespace ZumbaAPI.Repository.DataManager
{
    /// <summary>
    /// Author: Francis Decena
    /// Date: 30/08/2020
    /// Description: This will handle the data factory for ActivitiesModel 
    /// </summary>
    public class ActivityManager : IActivityRepository<ActivitiesModel>
    {
        #region Properties
        private readonly ILogger<ActivityManager> _logger;
        private readonly ZumbaDbContext _zumbaDbContext;
        private readonly IConfiguration _configuration;
        #endregion

        #region Contructor
        public ActivityManager(ILogger<ActivityManager> logger, ZumbaDbContext zumbaDbContext, IConfiguration configuration)
        {
            _logger = logger;
            _zumbaDbContext = zumbaDbContext;
            _configuration = configuration;
        }
        #endregion

        /// <summary>
        /// This will create a new activity 
        /// </summary>
        /// <param name="activitiesModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> CreateActivity(ActivitiesModel activitiesModel)
        {
            try
            {
                //check if the activity name is already exist
                var activity = await _zumbaDbContext.ActivitiesModels.FirstOrDefaultAsync(x => x.ActivityName == activitiesModel.ActivityName);

                if (activity != null)
                {
                    return new ResponseModel()
                    {
                        Message = string.Format($"Activity name {activitiesModel.ActivityName} is already exist"),
                        Code = 900
                    };
                }

                //Creata a new ActivitiesModel object
                var activities = new ActivitiesModel()
                {
                    ActivityName = activitiesModel.ActivityName,
                    ActivityDescription = activitiesModel.ActivityDescription,
                    ActivityLink = activitiesModel.ActivityDescription,
                    DateCreated = DateTime.Now,
                    IsActive = false
                };

                await _zumbaDbContext.ActivitiesModels.AddAsync(activities);

                var result = await _zumbaDbContext.SaveChangesAsync() > 0;

                if (!result)
                {
                    return new ResponseModel()
                    {
                        Message = "Activity not successfully created",
                        Code = 500
                    };
                }

                return new ResponseModel()
                {
                    Message = string.Format($"Activity {activitiesModel.ActivityName} succesfully created."),
                    Code = 201
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in ActivityManager||CreateActivity Message:{ex.Message}"),
                    Code = 500
                };
            }
        }

        /// <summary>
        /// This will delete an activity 
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns></returns>
        public async Task<ResponseModel> DeleteActivity(string activityName)
        {
            try
            {
                //Check if the activity is exist
                //If exist delete it 
                var activity = await _zumbaDbContext.ActivitiesModels.FirstOrDefaultAsync(x => x.ActivityName == activityName);

                if (activity == null)
                {
                    return new ResponseModel()
                    {
                        Message = string.Format($"Activity name {activityName} is not exist"),
                        Code = 400
                    };
                }

                _zumbaDbContext.Remove(activity);

                var result = await _zumbaDbContext.SaveChangesAsync() > 0;

                if (!result)
                {
                    return new ResponseModel()
                    {
                        Message = "Activity not successfully deleted",
                        Code = 500
                    };
                }

                return new ResponseModel()
                {
                    Message = string.Format($"Activity {activityName} succesfully deleted."),
                    Code = 200
                };

            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in ActivityManager||DeleteActivity Message:{ex.Message}"),
                    Code = 500
                };
            }
        }

        /// <summary>
        /// This will get an activity by itsactivityName
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns></returns>
        public async Task<ActivitiesModel> GetActivity(string activityName)
        {
            try
            {
                return await _zumbaDbContext.ActivitiesModels.FirstOrDefaultAsync(x => x.ActivityName == activityName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This will get all the activity
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ActivitiesModel>> GetAll()
        {
            try
            {
                return await _zumbaDbContext.ActivitiesModels.OrderByDescending(x => x.DateCreated).ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// This will update an activity
        /// </summary>
        /// <param name="activitiesModel"></param>
        /// <returns></returns>
        public async Task<ResponseModel> UpdateActivity(ActivitiesModel activitiesModel)
        {
            try
            {
                //Check if the activityname exist
                var activity = await _zumbaDbContext.ActivitiesModels.FirstOrDefaultAsync(x => x.ActivityName == activitiesModel.ActivityName);

                if (activity == null)
                {
                    return new ResponseModel()
                    {
                        Message = "Activity is not exist",
                        Code = 400
                    };
                }

                //Create new ActivitiesModel if there is new value in each properties
                if (activitiesModel.ActivityName != null)
                {
                    activity.ActivityName = activitiesModel.ActivityName;
                }
                if (activitiesModel.ActivityDescription != null)
                {
                    activity.ActivityDescription = activitiesModel.ActivityDescription;
                }
                if (activitiesModel.ActivityLink != null)
                {
                    activity.ActivityLink = activitiesModel.ActivityLink;
                }
                if (!activitiesModel.IsActive)
                {
                    activity.IsActive = false;
                }

                //save the upload profile
                var result = await _zumbaDbContext.SaveChangesAsync() > 0;

                if (!result)
                {
                    return new ResponseModel()
                    {
                        Message = "Activity not successfully updated",
                        Code = 500
                    };
                }

                return new ResponseModel()
                {
                    Message = "Activity successfully updated",
                    Code = 200
                };
            }
            catch (Exception ex)
            {
                return new ResponseModel()
                {
                    Message = string.Format($"Error encountered in ActivityManager||UpdateActivity Message:{ex.Message}"),
                    Code = 500
                };
            }
        }
    }
}
