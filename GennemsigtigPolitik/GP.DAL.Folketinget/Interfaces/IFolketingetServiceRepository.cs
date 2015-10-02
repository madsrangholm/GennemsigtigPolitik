using System.Collections.Generic;
using System.Threading.Tasks;
using GP.DAL.Folketinget.Model.Aktør;
using GP.DAL.Folketinget.Model.Dokument;
using GP.DAL.Folketinget.Model.Møde;
using GP.DAL.Folketinget.Model.Øvrige;

namespace GP.DAL.Folketinget.Interfaces
{
    public interface IFolketingetServiceRepository
    {
        #region Aktør

        IEnumerable<Aktør> AktørList();
        IEnumerable<AktørAktør> AktørAktørList();
        IEnumerable<AktørType> AktørTypeList();

        #endregion
        #region Dokument
        IEnumerable<Dokument> DokumentList();
        IEnumerable<Dokumentation> DokumentationList();//No data
        IEnumerable<DokumentKategori> DokumentKategoriList(); 
        IEnumerable<DokumentStatus> DokumentStatusList(); 
        IEnumerable<DokumentType> DokumentTypeList();
        IEnumerable<Fil> FilList();
        IEnumerable<Nyhed> NyhedList();//No data
        IEnumerable<Omtryk> OmtrykList();
        IEnumerable<Tale> TaleList();//No data
        IEnumerable<Video> VideoList();//No data
        #endregion

        #region Møde
        IEnumerable<Afstemning> AfstemningList();
        IEnumerable<Afstemningstype> AfstemningstypeList();
        IEnumerable<Dagsordenspunkt> DagsordenspunktList();
        IEnumerable<Møde> MødeList();
        IEnumerable<MødeStatus> MødeStatusList();
        IEnumerable<MødeType> MødeTypeList();
        IEnumerable<Stemme> StemmeList();
        IEnumerable<StemmeType> StemmeTypeList();
        #endregion
        #region Øvrige
        IEnumerable<KolonneBeskrivelse> KolonneBeskrivelseList();
        IEnumerable<Slettet> SlettetList();
        IEnumerable<SlettetMap> SlettetMapList();
        IEnumerable<TabelBeskrivelse> TabelBeskrivelseList();
        #endregion
    }
}