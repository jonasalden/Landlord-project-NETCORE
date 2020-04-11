using System;
using System.Linq;

namespace Landlord_project.Data
{
    public static class DbInitializer
    {
        public static void Seed(DataContext context)
        {
            if (!context.Residences.Any())
            {
                #region Residences seed
                var residences = new Residence[]
                {
                    new Residence {Address = "Kungsgatan 11", Area = "Örebro", Featured = false, CanRental = true, DateBuilt = DateTime.Parse("1990-02-14"), ApplicationFrom = DateTime.Parse("2020-04-24"), DateRenovated = DateTime.Parse("2001-11-10"), Description = "Centralt läge", Estate = "Victoriahuset", FloorNumber = 2, RentalPrice = 9560, Rooms = 2, ShowFrom = DateTime.Parse("2020-02-10"), ShowTo = DateTime.Parse("2020-02-20"), Size = 70, TypeOfResidence = ResidenceGroupType.Normal, ImageName = "residence_1.jpg", ImageMimeType = "image/jpeg"},
                    new Residence {Address = "Värngatan 4", Area = "Örebro", Featured = true, CanRental = true, DateBuilt = DateTime.Parse("1922-12-04"), ApplicationFrom = DateTime.Parse("2020-02-01"), DateRenovated = DateTime.Parse("2002-05-20"), Description = "Gammal militärbyggnad", Estate = "I3 regementet", FloorNumber = 4, RentalPrice = 4578, Rooms = 1, ShowFrom = DateTime.Parse("2020-02-10"), ShowTo = DateTime.Parse("2020-02-20"), Size = 36, TypeOfResidence = ResidenceGroupType.Normal, ImageName = "residence_2.jpg", ImageMimeType = "image/jpeg"},
                    new Residence {Address = "Studentvägen 25", Area = "Västerås", Featured = false, CanRental = false, DateBuilt = DateTime.Parse("2005-04-28"), ApplicationFrom = DateTime.Parse("2020-04-24"), DateRenovated = DateTime.Parse("2001-11-10"), Description = "Studentbostad", Estate = "Varianten", FloorNumber = 1, RentalPrice = 2030, Rooms = 1, ShowFrom = DateTime.Parse("2020-02-10"), ShowTo = DateTime.Parse("2020-02-20"), Size = 14, TypeOfResidence = ResidenceGroupType.Student, ImageName = "residence_3.jpg", ImageMimeType = "image/jpeg"}
                };

                foreach (var residence in residences)
                {
                    context.Residences.Add(residence);
                }
                context.SaveChanges();
                #endregion

                #region Tenants seed
                var tenants = new Tenant[]
                {
                    new Tenant{FirstName = "Jonas", LastName = "Aldén", Age = 26, Email = "jonas@mail.com", HasResidence = true, Phone = "0705555", Salary = 20000},
                    new Tenant{FirstName = "Petra", LastName = "Åkerdahl", Age = 24, Email = "petra@mail.com", HasResidence = false, Phone = "070444", Salary = 14000}
                };
                foreach (var tenant in tenants)
                {
                    context.Tenants.Add(tenant);
                }
                context.SaveChanges();

                #endregion

                #region Residence Assignment
                var residenceAssignments = new ResidenceAssignment[]
                {
                    new ResidenceAssignment{ResidenceID = residences.Single(r => r.Estate.ToLower() == "victoriahuset").Id,
                    TenantID = tenants.Single(t => t.FirstName.ToLower() == "jonas").Id}
                };

                foreach (var resAssignment in residenceAssignments)
                {
                    context.ResidenceAssignments.Add(resAssignment);
                }
                context.SaveChanges();
                #endregion
            }
        }
    }
}
