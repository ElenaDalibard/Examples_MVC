﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using EcommerceElena.Models;
using IdentityModel.Client;

namespace EcommerceElena.DataAccess
{
    public class EFRepository<T> : Repository<T> where T : class
    {
        //Instanciation du Contexte Entity FrameWork
        EDMTireLire EFContexte = new EDMTireLire();

        public virtual T Ajouter(T entite)
        {
            try
            {
                T Resultat = EFContexte.Set<T>().Add(entite);
                EFContexte.SaveChanges();
                return Resultat;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual IEnumerable<T> Lister()
        {
            return EFContexte.Set<T>().ToList();
        }

        public virtual T Modifier(T entite)
        {
            try
            {
                EFContexte.Entry<T>(entite).State = System.Data.Entity.EntityState.Modified;
                EFContexte.SaveChanges();
                return entite;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual bool Supprimer(int id)
        {
            try
            {
                EFContexte.Set<T>().Remove(EFContexte.Set<T>().Find(id));
                EFContexte.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual T Trouver(int id)
        {
            return EFContexte.Set<T>().Find(id);
        }
    }
}