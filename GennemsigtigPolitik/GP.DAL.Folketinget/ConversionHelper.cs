using GP.BLL.Model.Folketinget;
using GP.DAL.Folketinget.Model.Aktør;

namespace GP.DAL.Folketinget
{
    public static class ConversionHelper
    {
        public static Actor ToActor(this Aktør aktør)
        {
            return new Actor
            {
                Biography = aktør.Biografi,
                EndDate = aktør.SlutDato,
                FirstName = aktør.Fornavn,
                GroupnameCard = aktør.GruppenavnKort,
                Id = aktør.Id,
                LastName = aktør.Efternavn,
                LastUpdated = aktør.Opdateringsdato,
                Name = aktør.Navn,
                PeriodId = aktør.PeriodeId,
                StartDate = aktør.StartDato,
                TypeId = aktør.TypeId
            };
        }
    }
}