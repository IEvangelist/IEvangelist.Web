"use strict";
var router_1 = require("@angular/router");
var home_component_1 = require("./home/home.component");
var contact_component_1 = require("./contact/contact.component");
var about_component_1 = require("./about/about.component");
var appRoutes = [
    { path: '', component: home_component_1.HomeComponent },
    { path: 'contact', component: contact_component_1.ContactComponent },
    { path: 'about', component: about_component_1.AboutComponent }
];
exports.appRoutingProviders = [];
exports.routing = router_1.RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map