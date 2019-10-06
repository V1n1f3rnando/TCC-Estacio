﻿using Oficina.com.Dados.Contextos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.com.Dados.Repositorios
{
    public class RepositorioGenerico<TEntity>
        where TEntity : class
    {
        
        public virtual void Insert(TEntity obj)
        {
            using (Context d = new Context())
            {
                d.Entry(obj).State = EntityState.Added;
                d.SaveChanges(); 
            }
        }

        public virtual void Update(TEntity obj)
        {
            using (Context d = new Context())
            {
                d.Entry(obj).State = EntityState.Modified; 
                d.SaveChanges(); 
            }
        }
        public virtual void Delete(TEntity obj)
        {
            using (Context d = new Context())
            {
                d.Entry(obj).State = EntityState.Deleted; 
                d.SaveChanges(); 
            }
        }
        {
            using (Context d = new Context())
            {
                return d.Set<TEntity>().ToList();
            }
        }
        {
            using (Context d = new Context())
            {
                return d.Set<TEntity>().Find(id);
            }
        }
    }
}