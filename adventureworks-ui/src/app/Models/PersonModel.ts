export class Person {
    BusinessEntityId: number;
    PersonType?: string;
    Title?: string;
    FirstName?: string;
    MiddleName?: string;
    LastName?: string;
    Suffix?: string;
    EmailPromotion?: number;

    constructor(
        BusinessEntityId: number,
        PersonType?: string,
        Title?: string,
        FirstName?: string,
        MiddleName?: string,
        LastName?: string,
        Suffix?: string,
        EmailPromotion?: number
    ) {
        this.BusinessEntityId = BusinessEntityId;
        this.PersonType = PersonType;
        this.Title = Title;
        this.FirstName = FirstName;
        this.MiddleName = MiddleName;
        this.LastName = LastName;
        this.Suffix = Suffix;
        this.EmailPromotion = EmailPromotion;
    }
}