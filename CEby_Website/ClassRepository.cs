﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CEby_Website.Data;
using Microsoft.Data.SqlClient.Server;
using Microsoft.EntityFrameworkCore;

namespace CEby_Website
{
    public class DatabaseAccessor
    {
        private static readonly minicstructorContext entities;

        static DatabaseAccessor()
        {
            entities = new minicstructorContext();
            entities.Database.OpenConnection();
        }

        public static minicstructorContext Instance
        {
            get
            {
                return entities;
            }
        }
    }

    public interface IClassRepository
    {
        ClassModel[] Classes { get; }
        ClassModel Class(int classId);
    }

    public class ClassModel
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public decimal ClassPrice { get; set; }
    }

    public class ClassRepository : IClassRepository
    {
        public ClassModel[] Classes
        {
            get
            {
                return DatabaseAccessor.Instance.Class
                    .Select(t => new ClassModel { 
                        ClassId = t.ClassId, 
                        ClassDescription = t.ClassDescription, 
                        ClassName = t.ClassName, 
                        ClassPrice = t.ClassPrice })
                    .ToArray();
            }
        }

        public ClassModel Class(int classId)
        {
            var schoolClass = DatabaseAccessor.Instance.Class
                .Where(t => t.ClassId == classId)
                .Select(t => new ClassModel
                {
                    ClassId = t.ClassId,
                    ClassDescription = t.ClassDescription,
                    ClassName = t.ClassName,
                    ClassPrice = t.ClassPrice
                })
                .First();

            return schoolClass;
        }
       /* public ClassModel[] ForClass(int classId)
        {
            return DatabaseAccessor.Instance.Class
                    .Where(t => t.ClassId == classId)
                    .Select(t => new ClassModel
                    {
                        ClassId = t.ClassId,
                        ClassName = t.ClassName,
                        ClassDescription = t.ClassDescription,
                        ClassPrice = t.ClassPrice
                    })
                    .ToArray();
        }*/
    }

}