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
export class ContactList {
    contacts: Array<IContact>;

    constructor(private http: HttpClient) { }

    created() {
        return this.http.fetch("http://localhost:52336/api/contacts").
            then(response => response.json()).then(data => {
                this.contacts = data;
            });
    }
}