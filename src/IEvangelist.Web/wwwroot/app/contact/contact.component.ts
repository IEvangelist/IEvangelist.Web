import { Component } from '@angular/core';


@Component({
    moduleId: module.id,
    templateUrl: 'contact.component.html'
})
export class ContactComponent {
    // https://www.zipcodeapi.com/rest/kcBSvjyRQL0GbLbuAT0TNKC5M2fGJxs4J4Xfnv6eh7UsS6WsZXmNHYSu07aKEDOo/info.json/53072/radians
}

export interface Timezone {
    timezone_identifier: string;
    timezone_abbr: string;
    utc_offset_sec: number;
    is_dst: string;
}

export interface AcceptableCityName {
    city: string;
    state: string;
}

export interface ZipCode {
    zip_code: string;
    lat: number;
    lng: number;
    city: string;
    state: string;
    timezone: Timezone;
    acceptable_city_names: AcceptableCityName[];
}