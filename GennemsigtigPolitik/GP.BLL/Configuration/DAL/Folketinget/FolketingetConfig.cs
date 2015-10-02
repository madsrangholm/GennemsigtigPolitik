using System.Configuration;
using GP.BLL.Interfaces.DAL.Folketinget;

namespace GP.BLL.Configuration.DAL.Folketinget
{
    public class FolketingetConfig : ConfigurationSection, IFolketingetConfig
    {
        
        [ConfigurationProperty("apiUrl", IsRequired = true)]
        public string ApiUrl => (string) this["apiUrl"];

        #region Aktør
        [ConfigurationProperty("aktørRoute", IsRequired = true)]
        public string AktørUrl => ApiUrl + (string) this["aktørRoute"];

        [ConfigurationProperty("aktørAktørRoute", IsRequired = true)]
        public string AktørAktørUrl => ApiUrl + (string) this["aktørAktørRoute"];

        [ConfigurationProperty("aktørTypeRoute", IsRequired = true)]
        public string AktørTypeUrl => ApiUrl + (string) this["aktørTypeRoute"];
        #endregion
        #region Dokument

        [ConfigurationProperty("dokumentRoute", IsRequired = true)]
        public string DokumentUrl => ApiUrl + (string) this["dokumentRoute"];

        [ConfigurationProperty("dokumentationRoute", IsRequired = true)]
        public string DokumentationUrl => ApiUrl + (string)this["dokumentationRoute"];

        [ConfigurationProperty("dokumentKategoriRoute", IsRequired = true)]
        public string DokumentKategoriUrl => ApiUrl + (string)this["dokumentKategoriRoute"];

        [ConfigurationProperty("dokumentStatusRoute", IsRequired = true)]
        public string DokumentStatusUrl => ApiUrl + (string)this["dokumentStatusRoute"];

        [ConfigurationProperty("dokumentTypeRoute", IsRequired = true)]
        public string DokumentTypeUrl => ApiUrl + (string)this["dokumentTypeRoute"];

        [ConfigurationProperty("filRoute", IsRequired = true)]
        public string FilUrl  => ApiUrl + (string) this["filRoute"];

        [ConfigurationProperty("nyhedRoute", IsRequired = true)]
        public string NyhedUrl => ApiUrl + (string)this["nyhedRoute"];

        [ConfigurationProperty("omtrykRoute", IsRequired = true)]
        public string OmtrykUrl  => ApiUrl + (string) this["omtrykRoute"];

        [ConfigurationProperty("taleRoute", IsRequired = true)]
        public string TaleUrl  => ApiUrl + (string) this["taleRoute"];

        [ConfigurationProperty("videoRoute", IsRequired = true)]
        public string VideoUrl  => ApiUrl + (string) this["videoRoute"];
        #endregion
        #region Møde
        [ConfigurationProperty("afstemningRoute", IsRequired = true)]
        public string AfstemningUrl  => ApiUrl + (string) this["afstemningRoute"];

        [ConfigurationProperty("afstemningstypeRoute", IsRequired = true)]
        public string AfstemningstypeUrl  => ApiUrl + (string) this["afstemningstypeRoute"];

        [ConfigurationProperty("dagsordenspunktRoute", IsRequired = true)]
        public string DagsordenspunktUrl => ApiUrl + (string)this["dagsordenspunktRoute"];

        [ConfigurationProperty("mødeRoute", IsRequired = true)]
        public string MødeUrl  => ApiUrl + (string) this["mødeRoute"];


        [ConfigurationProperty("mødeStatusRoute", IsRequired = true)]
        public string MødeStatusUrl  => ApiUrl + (string) this["mødeStatusRoute"];

        [ConfigurationProperty("mødeTypeRoute", IsRequired = true)]
        public string MødeTypeUrl  => ApiUrl + (string) this["mødeTypeRoute"];

        [ConfigurationProperty("stemmeRoute", IsRequired = true)]
        public string StemmeUrl  => ApiUrl + (string) this["stemmeRoute"];

        [ConfigurationProperty("stemmeTypeRoute", IsRequired = true)]
        public string StemmeTypeUrl  => ApiUrl + (string) this["stemmeTypeRoute"];
        #endregion
        #region Øvrige
        [ConfigurationProperty("kolonneBeskrivelseRoute", IsRequired = true)]
        public string KolonneBeskrivelseUrl  => ApiUrl + (string) this["kolonneBeskrivelseRoute"];

        [ConfigurationProperty("slettetRoute", IsRequired = true)]
        public string SlettetUrl  => ApiUrl + (string) this["slettetRoute"];

        [ConfigurationProperty("slettetMapRoute", IsRequired = true)]
        public string SlettetMapUrl  => ApiUrl + (string) this["slettetMapRoute"];

        [ConfigurationProperty("tabelBeskrivelseRoute", IsRequired = true)]
        public string TabelBeskrivelseUrl  => ApiUrl + (string) this["tabelBeskrivelseRoute"];
        #endregion
    }
}