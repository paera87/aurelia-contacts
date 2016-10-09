import {inject} from "aurelia-framework";
import {Router} from "aurelia-router";

@inject(Router)
export class App {
    router: Router;

    constructor() { }

    configureRouter(config, router: Router) {
        this.router = router;

        config.title = "Contact manager";
        config.map([
            { route: '', moduleId: './views/no-selection', title: 'Select' },
            { route: 'contacts/:id', moduleId: './views/contact-detail', name: 'contacts' }
        ]);
    }
}