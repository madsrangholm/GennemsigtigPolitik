namespace GP.BLL.Interfaces.DAL.Folketinget
{
    public interface IFolketingetConfig
    {
        #region Aktør
        string AktørUrl { get; }
        string AktørAktørUrl { get; }
        string AktørTypeUrl { get; }
        #endregion
        #region Dokument
        string DokumentUrl { get; }
        string DokumentationUrl { get; }
        string DokumentKategoriUrl { get; }
        string DokumentStatusUrl { get; }
        string DokumentTypeUrl { get; }
        string FilUrl { get; }
        string NyhedUrl { get; }
        string OmtrykUrl { get; }
        string TaleUrl { get; }
        string VideoUrl { get; }
        #endregion
        #region Møde
        string AfstemningUrl { get; }
        string AfstemningstypeUrl { get; }
        string DagsordenspunktUrl { get; }
        string MødeUrl { get; }
        string MødeStatusUrl { get; }
        string MødeTypeUrl { get; }
        string StemmeUrl { get; }
        string StemmeTypeUrl { get; }
        #endregion
        #region Øvrige
        string KolonneBeskrivelseUrl { get; }
        string SlettetUrl { get; }
        string SlettetMapUrl { get; }
        string TabelBeskrivelseUrl { get; }
        #endregion
    }
}