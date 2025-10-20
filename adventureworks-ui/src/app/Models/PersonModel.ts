export class Person {
    businessEntityId: number;
    PersonType?: string;
    Title?: string;
    firstName?: string;
    MiddleName?: string;
    lastName?: string;
    Suffix?: string;
    EmailPromotion?: number;

    constructor(
        businessEntityId: number,
        PersonType?: string,
        Title?: string,
        firstName?: string,
        MiddleName?: string,
        lastName?: string,
        Suffix?: string,
        EmailPromotion?: number
    ) {
        this.businessEntityId = businessEntityId;
        this.PersonType = PersonType;
        this.Title = Title;
        this.firstName = firstName;
        this.MiddleName = MiddleName;
        this.lastName = lastName;
        this.Suffix = Suffix;
        this.EmailPromotion = EmailPromotion;
    }
}