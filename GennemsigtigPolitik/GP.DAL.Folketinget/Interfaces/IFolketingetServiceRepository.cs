using System.Collections.Generic;
using System.Threading.Tasks;
using GP.BLL.Model.Folketinget;

namespace GP.DAL.Folketinget.Interfaces
{
    public interface IFolketingetServiceRepository
    {
        #region Aktør

        Task<IEnumerable<Actor>> AktørList();
        //Task<IEnumerable<AktørAktør>> AktørAktørList();
        //Task<IEnumerable<AktørType>> AktørTypeList();

        #endregion
        //#region Dokument
        //Task<IEnumerable<Dokument>> DokumentList();
        //Task<IEnumerable<Dokumentation>> DokumentationList();//No data
        //Task<IEnumerable<DokumentKategori>> DokumentKategoriList(); 
        //Task<IEnumerable<DokumentStatus>> DokumentStatusList(); 
        //Task<IEnumerable<DokumentType>> DokumentTypeList();
        //Task<IEnumerable<Fil>> FilList();
        //Task<IEnumerable<Nyhed>> NyhedList();//No data
        //Task<IEnumerable<Omtryk>> OmtrykList();
        //Task<IEnumerable<Tale>> TaleList();//No data
        //Task<IEnumerable<Video>> VideoList();//No data
        //#endregion

        //#region Møde
        //Task<IEnumerable<Afstemning>> AfstemningList();
        //Task<IEnumerable<Afstemningstype>> AfstemningstypeList();
        //Task<IEnumerable<Dagsordenspunkt>> DagsordenspunktList();
        //Task<IEnumerable<Møde>> MødeList();
        //Task<IEnumerable<MødeStatus>> MødeStatusList();
        //Task<IEnumerable<MødeType>> MødeTypeList();
        //Task<IEnumerable<Stemme>> StemmeList();
        //Task<IEnumerable<StemmeType>> StemmeTypeList();
        //#endregion
        //#region Øvrige
        //Task<IEnumerable<KolonneBeskrivelse>> KolonneBeskrivelseList();
        //Task<IEnumerable<Slettet>> SlettetList();
        //Task<IEnumerable<SlettetMap>> SlettetMapList();
        //Task<IEnumerable<TabelBeskrivelse>> TabelBeskrivelseList();
        //#endregion
    }
}