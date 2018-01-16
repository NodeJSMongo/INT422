using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment5.Models;

namespace Assignment5.Controllers
{
    public class Manager
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
                cfg.CreateMap<Models.Album, Controllers.AlbumBase>();

                cfg.CreateMap<Models.MediaType, Controllers.MediaTypeBase>();

                cfg.CreateMap<Models.Track, Controllers.TrackBase>();
                cfg.CreateMap<Models.Track, Controllers.TrackWithDetail>();
                cfg.CreateMap<Controllers.TrackAdd, Models.Track>();

                // Attention 04 - Notice the definitions that help build the HTML Forms
                cfg.CreateMap<Controllers.TrackBase, Controllers.TrackAddForm>();
                cfg.CreateMap<Controllers.TrackWithDetail, Controllers.TrackAddForm>();

            });

            mapper = config.CreateMapper();

            // Turn off the Entity Framework (EF) proxy creation features
            // We do NOT want the EF to track changes - we'll do that ourselves
            ds.Configuration.ProxyCreationEnabled = false;

            // Also, turn off lazy loading...
            // We want to retain control over fetching related objects
            ds.Configuration.LazyLoadingEnabled = false;
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
        public IEnumerable<AlbumBase> AlbumGetAll()
        {
            return mapper.Map<IEnumerable<AlbumBase>>(ds.Albums);
        }


        public AlbumBase AlbumGetById(int id)
        {
            var o = ds.Albums.Find(id);
            return (o == null) ? null : mapper.Map<AlbumBase>(o);
        }


        public IEnumerable<MediaTypeBase> MediaTypeGetAll()
        {
            return mapper.Map<IEnumerable<MediaTypeBase>>(ds.MediaTypes);
        }

        public MediaTypeBase MediaTypeGetById(int id)
        {
            var o = ds.MediaTypes.Find(id);
            return (o == null) ? null : mapper.Map<MediaTypeBase>(o);


        }


        public TrackBase TrackGetById(int id)
        {

            var o = ds.Tracks.Find(id);
            return (o == null) ? null : mapper.Map<TrackBase>(o);

        }

        public IEnumerable<TrackBase> TrackGetAll()
        {



            return mapper.Map<IEnumerable<TrackBase>>(ds.Tracks);

        }


        public IEnumerable<TrackWithDetail> TrackGetAllWithDetail()
        {


            var o = ds.Tracks.Include("MediaType").Include("Album");

            return mapper.Map<IEnumerable<TrackWithDetail>>(o);
        }

        public TrackWithDetail TrackGetByIdWithDetail(int id)
        {
            var o = ds.Tracks.Include("MediaType").Include("Album").SingleOrDefault(p => p.TrackId == id);
            return (o == null) ? null : mapper.Map<TrackWithDetail>(o);

        }


        public TrackWithDetail TrackAdd(TrackAddForm newItem)
        {
            System.Diagnostics.Debug.WriteLine("Adding a track");

            var a = ds.Albums.Find(newItem.AlbumId);
            var t = ds.MediaTypes.Find(newItem.MediaTypeId);

            System.Diagnostics.Debug.WriteLine("Media Type is " + t);



            if (a == null)
            {
                return null;
            }

            else
            {
                var addedItem = ds.Tracks.Add(mapper.Map<Track>(newItem));
                addedItem.Album = a;
                ds.SaveChanges();
                return (addedItem == null) ? null : mapper.Map<TrackWithDetail>(addedItem);

            }

       }
     } 
  }