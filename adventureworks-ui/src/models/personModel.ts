export class Person {
    businessEntityId: number;
    personType?: string;
    title?: string;
    firstName?: string;
    middleName?: string;
    lastName?: string;
    suffix?: string;
    emailPromotion?: number;

    constructor(
        businessEntityId: number,
        personType?: string,
        title?: string,
        firstName?: string,
        middleName?: string,
        lastName?: string,
        suffix?: string,
        emailPromotion?: number
    ) {
        this.businessEntityId = businessEntityId;
        this.personType = personType;
        this.title = title;
        this.firstName = firstName;
        this.middleName = middleName;
        this.lastName = lastName;
        this.suffix = suffix;
        this.emailPromotion = emailPromotion;
    }
}