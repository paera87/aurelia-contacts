import {inject} from "aurelia-framework";
import {HttpClient} from "aurelia-fetch-client";

interface IContact {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    phoneNumber: string;
}

@inject(HttpClient)
export class ContactDetail {
    contact: IContact;

    constructor(private http: HttpClient) { }

    activate(params) {
        return this.http.fetch("http://localhost:52336/api/contacts/" + params.id).
            then(response => response.json()).then(data => {
                this.contact = data;
                // todo make the number id (here2) come from whatever is clicked in contact-list
            });
    }
}