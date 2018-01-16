using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment_3.Models;
using System.Web.Mvc;

namespace Assignment_3.Controllers
{
    public class Manager : Controller
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        // AutoMapper instance
        public IMapper mapper;

        public Manager()
        {
            // If necessary, add more constructor code here...

            // Configure the AutoMapper components
            var config = new MapperConfiguration(cfg =>
            {
                // Define the mappings below, for example...
                // cfg.CreateMap<SourceType, DestinationType>();
                // cfg.CreateMap<Employee, EmployeeBase>();
                cfg.CreateMap<Models.Employee, Controllers.EmployeeBase>();

                cfg.CreateMap<Controllers.EmployeeBase, Controllers.EmployeeEditContactInfoForm>();

                cfg.CreateMap<Controllers.EmployeeEditContactInfo, Controllers.EmployeeEditContactInfoForm>();

                cfg.CreateMap<Models.Employee,Controllers.EmployeeAdd>();

                cfg.CreateMap<Models.Track, Controllers.TrackBase>();

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
        }

        internal object Map<T>(EmployeeBase o)
        {
            throw new NotImplementedException();
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()

        // Get all Employees
        public IEnumerable<EmployeeBase> EmployeeGetAll()
        {
            // The ds object is the data store
            // It has a collection for each entity it manages

            return mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeBase>>(ds.Employees);
        }

        // Get one Employee by its identifier
        public EmployeeBase EmployeeGetById(int id)
        {
            // Attempt to fetch the object
            var o = ds.Employees.Find(id);

            // Return the result, or null if not found
            return (o == null) ? null : mapper.Map<Employee, EmployeeBase>(o);
        }

        // Add new Employee
        public EmployeeBase EmployeeAdd(EmployeeAdd newItem)
        {
            // Attempt to add the new item
            // Notice how we map the incoming data to the design model object
            var addedItem = ds.Employees.Add(mapper.Map<EmployeeAdd, Employee>(newItem));
            ds.SaveChanges();

            // If successful, return the added item, mapped to a view model object
            return (addedItem == null) ? null : mapper.Map<Employee, EmployeeBase>(addedItem);
        }

        // Attention 06 - Edit Employee, contact info
        public EmployeeBase EmployeeEditContactInfo(EmployeeEditContactInfo newItem)
        {
            // Attempt to fetch the object
            var o = ds.Employees.Find(newItem.EmployeeId);

            if (o == null)
            {
                // Problem - item was not found, so return
                return null;
            }
            else
            {
                // Update the object with the incoming values
                ds.Entry(o).CurrentValues.SetValues(newItem);
                ds.SaveChanges();

                // Prepare and return the object
                return mapper.Map<Employee, EmployeeBase>(o);
            }
        }

        // Attention 07 - Delete Employee
        // Notice the return type, which works for us in learning (getting started) situations
        public bool EmployeeDelete(int id)
        {
            // Attempt to fetch the object to be deleted
            var itemToDelete = ds.Employees.Find(id);

            if (itemToDelete == null)
            {
                return false;
            }
            else
            {
                // Remove the object
                ds.Employees.Remove(itemToDelete);
                ds.SaveChanges();

                return true;
            }
        }

        public IEnumerable<TrackBase> TrackGetAll()
        {
            var t = ds.Tracks.OrderBy(o => o.AlbumId).ThenBy(o => o.Name);
            return mapper.Map<IEnumerable<Track>, IEnumerable<TrackBase>>(t);
            
        }


        public IEnumerable<TrackBase> TrackGetAllPop()
        {
            var t = ds.Tracks.Where(o => o.GenreId == 9).OrderBy(o => o.Name);
            return mapper.Map<IEnumerable<TrackBase>>(t);
        }


        public IEnumerable<TrackBase> TrackGetAllDeepPurple()
        {
            var t = ds.Tracks.Where(o => o.Composer.Contains("Jon Lord")).OrderBy(o => o.TrackId);
            return mapper.Map<IEnumerable<TrackBase>>(t);
        }



        public IEnumerable<TrackBase> TrackGetAllTop100Longest()
        {
            var t = ds.Tracks.OrderByDescending(o => o.Milliseconds).Take(100);
            return mapper.Map<IEnumerable<TrackBase>>(t);
        }

    }
}