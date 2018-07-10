using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Mascota
{
    public class MascotaPersistence
    {
        public long Add(Model.Mascota model)
        {
            if (model == null)
                return 0;

            try
            {
                using (var ctx = new PetZooContext())
                {
                    ctx.Mascota.Add(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                //log
            }

            return model.IdMascota;
        }

        public bool Update(Model.Mascota model)
        {
            bool success = false;

            if (model == null)
                return false;

            try
            {
                using (var ctx = new PetZooContext())
                {
                    ctx.Mascota.Attach(model);
                    ctx.Entry(model).State = EntityState.Modified;
                    success = ctx.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                //log
            }

            return success;
        }

        public IEnumerable<Model.Mascota> GetAll()
        {
            IEnumerable<Model.Mascota> models = new List<Model.Mascota>();

            try
            {
                using (var ctx = new PetZooContext())
                {
                    models = ctx.Mascota.AsNoTracking()
                                .AsEnumerable();
                }
            }
            catch (Exception)
            {
                //log
            }

            return models;
        }

        public IEnumerable<Model.Mascota> GetAllWithPhotos()
        {
            IEnumerable<Model.Mascota> models = new List<Model.Mascota>();

            try
            {
                using (var ctx = new PetZooContext())
                {
                    models = ctx.Mascota.AsNoTracking()
                                .Include(m => m.Foto.Select(f => f.Path))
                                .AsEnumerable();
                }
            }
            catch (Exception)
            {
                //log
            }

            return models;
        }

        public Model.Mascota GetById(long id)
        {
            Model.Mascota model = new Model.Mascota();

            try
            {
                using (var ctx = new PetZooContext())
                {
                    model = ctx.Mascota.AsNoTracking()
                                .SingleOrDefault(m => m.IdMascota == id);
                }
            }
            catch (Exception)
            {
                //log
            }

            return model;
        }

        public Model.Mascota GetWithPhotosById(long id)
        {
            Model.Mascota model = new Model.Mascota();

            try
            {
                using (var ctx = new PetZooContext())
                {
                    model = ctx.Mascota.AsNoTracking()
                                .Include(m => m.Foto.Select(f => f.Path))
                                .SingleOrDefault(m => m.IdMascota == id);
                }
            }
            catch (Exception)
            {
                //log
            }

            return model;
        }

        public Model.Mascota GetFullById(long id)
        {
            Model.Mascota model = new Model.Mascota();

            try
            {
                using (var ctx = new PetZooContext())
                {
                    model = ctx.Mascota.AsNoTracking()
                                .Include(m => m.Foto.Select(f => f.Path))
                                .Include(m => m.EstadoMascota)
                                .Include(m => m.Comportamiento)
                                .Include(m => m.ClaseMascota)
                                .Include(m => m.Raza)
                                .Include(m => m.Tamano)
                                .SingleOrDefault(m => m.IdMascota == id);
                }
            }
            catch (Exception)
            {
                //log
            }

            return model;
        }
    }
}
