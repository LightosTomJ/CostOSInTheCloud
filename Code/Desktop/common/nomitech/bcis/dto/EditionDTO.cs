using System;

namespace Desktop.common.nomitech.bcis.dto
{

    public class EditionDTO
    {
        private string editionId;

        private string editionCode;

        private string editionDesc;

        private decimal priceUpperBound;

        private decimal priceLowerBound;

        private string pricesCurrent;

        private DateTime publishedDate;

        private bool onLine;

        private string pdfName;

        private decimal locationFactor;

        private string publicationId;

        private string publicationCode;

        private string publicationDesc;

        private string publicationEnvironment;

        public virtual string EditionId
        {
            get
            {
                return this.editionId;
            }
            set
            {
                this.editionId = value;
            }
        }


        public virtual string EditionCode
        {
            get
            {
                return this.editionCode;
            }
            set
            {
                this.editionCode = value;
            }
        }


        public virtual string EditionDesc
        {
            get
            {
                return this.editionDesc;
            }
            set
            {
                this.editionDesc = value;
            }
        }


        public virtual decimal PriceUpperBound
        {
            get
            {
                return this.priceUpperBound;
            }
            set
            {
                this.priceUpperBound = value;
            }
        }


        public virtual decimal PriceLowerBound
        {
            get
            {
                return this.priceLowerBound;
            }
            set
            {
                this.priceLowerBound = value;
            }
        }


        public virtual string PricesCurrent
        {
            get
            {
                return this.pricesCurrent;
            }
            set
            {
                this.pricesCurrent = value;
            }
        }


        public virtual DateTime PublishedDate
        {
            get
            {
                return this.publishedDate;
            }
            set
            {
                this.publishedDate = value;
            }
        }


        public virtual bool OnLine
        {
            get
            {
                return this.onLine;
            }
            set
            {
                this.onLine = value;
            }
        }


        public virtual string PdfName
        {
            get
            {
                return this.pdfName;
            }
            set
            {
                this.pdfName = value;
            }
        }


        public virtual decimal LocationFactor
        {
            get
            {
                return this.locationFactor;
            }
            set
            {
                this.locationFactor = value;
            }
        }


        public virtual string PublicationId
        {
            get
            {
                return this.publicationId;
            }
            set
            {
                this.publicationId = value;
            }
        }


        public virtual string PublicationCode
        {
            get
            {
                return this.publicationCode;
            }
            set
            {
                this.publicationCode = value;
            }
        }


        public virtual string PublicationDesc
        {
            get
            {
                return this.publicationDesc;
            }
            set
            {
                this.publicationDesc = value;
            }
        }


        public virtual string PublicationEnvironment
        {
            get
            {
                return this.publicationEnvironment;
            }
            set
            {
                this.publicationEnvironment = value;
            }
        }


        public override string ToString()
        {
            return this.editionCode + " - " + this.editionDesc;
        }
    }


    // Location:              C:\Users\TomJames_zyl8law\Lightos\Lightos Hub - Documents\01-Clients\CostOS\Solution from Java Source Code\common\!\nomitech\bcis\dto\EditionDTO.class
    // Java compiler version: 8 (52.0)
    // JD-Core Version:       1.0.7
}