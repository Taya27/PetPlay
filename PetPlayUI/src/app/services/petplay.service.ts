/* tslint:disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v11.19.2.0 (NJsonSchema v9.10.73.0 (Newtonsoft.Json v9.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, from as _observableFrom, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

@Injectable()
export class PetPlayService {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    /**
     * @param model (optional) 
     * @return Success
     */
    apiAuthRegisterPost(model: RegistrationViewModel | null | undefined): Observable<string> {
        let url_ = this.baseUrl + "/api/auth/register";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(model);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processApiAuthRegisterPost(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processApiAuthRegisterPost(<any>response_);
                } catch (e) {
                    return <Observable<string>><any>_observableThrow(e);
                }
            } else
                return <Observable<string>><any>_observableThrow(response_);
        }));
    }

    protected processApiAuthRegisterPost(response: HttpResponseBase): Observable<string> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <string>JSON.parse(_responseText, this.jsonParseReviver);
            return _observableOf(result200);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            result400 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result400);
            }));
        } else if (status === 500) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result500: any = null;
            result500 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result500);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<string>(<any>null);
    }

    /**
     * @param model (optional) 
     * @return Success
     */
    apiAuthLoginPost(model: LoginViewModel | null | undefined): Observable<string> {
        let url_ = this.baseUrl + "/api/auth/login";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(model);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processApiAuthLoginPost(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processApiAuthLoginPost(<any>response_);
                } catch (e) {
                    return <Observable<string>><any>_observableThrow(e);
                }
            } else
                return <Observable<string>><any>_observableThrow(response_);
        }));
    }

    protected processApiAuthLoginPost(response: HttpResponseBase): Observable<string> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <string>JSON.parse(_responseText, this.jsonParseReviver);
            return _observableOf(result200);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            result400 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result400);
            }));
        } else if (status === 500) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result500: any = null;
            result500 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result500);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<string>(<any>null);
    }

    /**
     * @param model (optional) 
     * @return Success
     */
    apiPetsAddPetPost(model: AddNewPetViewModel | null | undefined): Observable<PetModel> {
        let url_ = this.baseUrl + "/api/pets/add-pet";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(model);

        let options_ : any = {
            body: content_,
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("post", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processApiPetsAddPetPost(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processApiPetsAddPetPost(<any>response_);
                } catch (e) {
                    return <Observable<PetModel>><any>_observableThrow(e);
                }
            } else
                return <Observable<PetModel>><any>_observableThrow(response_);
        }));
    }

    protected processApiPetsAddPetPost(response: HttpResponseBase): Observable<PetModel> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <PetModel>JSON.parse(_responseText, this.jsonParseReviver);
            return _observableOf(result200);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            result400 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result400);
            }));
        } else if (status === 500) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result500: any = null;
            result500 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result500);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<PetModel>(<any>null);
    }

    /**
     * @return Success
     */
    apiPetsDeletePetByPetIdDelete(petId: string): Observable<PetModel> {
        let url_ = this.baseUrl + "/api/pets/delete-pet/{petId}";
        if (petId === undefined || petId === null)
            throw new Error("The parameter 'petId' must be defined.");
        url_ = url_.replace("{petId}", encodeURIComponent("" + petId)); 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("delete", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processApiPetsDeletePetByPetIdDelete(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processApiPetsDeletePetByPetIdDelete(<any>response_);
                } catch (e) {
                    return <Observable<PetModel>><any>_observableThrow(e);
                }
            } else
                return <Observable<PetModel>><any>_observableThrow(response_);
        }));
    }

    protected processApiPetsDeletePetByPetIdDelete(response: HttpResponseBase): Observable<PetModel> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <PetModel>JSON.parse(_responseText, this.jsonParseReviver);
            return _observableOf(result200);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            result400 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result400);
            }));
        } else if (status === 500) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result500: any = null;
            result500 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result500);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<PetModel>(<any>null);
    }

    /**
     * @return Success
     */
    apiUsersGetAllUsersGet(): Observable<UserModel[]> {
        let url_ = this.baseUrl + "/api/users/get-all-users";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processApiUsersGetAllUsersGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processApiUsersGetAllUsersGet(<any>response_);
                } catch (e) {
                    return <Observable<UserModel[]>><any>_observableThrow(e);
                }
            } else
                return <Observable<UserModel[]>><any>_observableThrow(response_);
        }));
    }

    protected processApiUsersGetAllUsersGet(response: HttpResponseBase): Observable<UserModel[]> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <UserModel[]>JSON.parse(_responseText, this.jsonParseReviver);
            return _observableOf(result200);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            result400 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result400);
            }));
        } else if (status === 500) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result500: any = null;
            result500 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result500);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<UserModel[]>(<any>null);
    }

    /**
     * @return Success
     */
    apiUsersGetUserByIdGet(id: string): Observable<UserModel> {
        let url_ = this.baseUrl + "/api/users/get-user/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id)); 
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Content-Type": "application/json", 
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processApiUsersGetUserByIdGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processApiUsersGetUserByIdGet(<any>response_);
                } catch (e) {
                    return <Observable<UserModel>><any>_observableThrow(e);
                }
            } else
                return <Observable<UserModel>><any>_observableThrow(response_);
        }));
    }

    protected processApiUsersGetUserByIdGet(response: HttpResponseBase): Observable<UserModel> {
        const status = response.status;
        const responseBlob = 
            response instanceof HttpResponse ? response.body : 
            (<any>response).error instanceof Blob ? (<any>response).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }};
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <UserModel>JSON.parse(_responseText, this.jsonParseReviver);
            return _observableOf(result200);
            }));
        } else if (status === 400) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result400: any = null;
            result400 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result400);
            }));
        } else if (status === 500) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            let result500: any = null;
            result500 = _responseText === "" ? null : <any>JSON.parse(_responseText, this.jsonParseReviver);
            return throwException("A server error occurred.", status, _responseText, _headers, result500);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap(_responseText => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf<UserModel>(<any>null);
    }
}

export interface RegistrationViewModel {
    firstName?: string | undefined;
    lastName?: string | undefined;
    email?: string | undefined;
    nickname?: string | undefined;
    password?: string | undefined;
}

export interface LoginViewModel {
    login?: string | undefined;
    password?: string | undefined;
}

export interface AddNewPetViewModel {
    nickname?: string | undefined;
    breed?: string | undefined;
    userId?: string | undefined;
}

export interface PetModel {
    id?: string | undefined;
    nickname?: string | undefined;
    breed?: string | undefined;
    userModel?: UserModel | undefined;
}

export interface UserModel {
    id?: string | undefined;
    firstName?: string | undefined;
    lastName?: string | undefined;
    email?: string | undefined;
    nickname?: string | undefined;
    pets?: PetModel[] | undefined;
}

export class SwaggerException extends Error {
    message: string;
    status: number; 
    response: string; 
    headers: { [key: string]: any; };
    result: any; 

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if(result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader(); 
            reader.onload = function() { 
                observer.next(this.result);
                observer.complete();
            }
            reader.readAsText(blob); 
        }
    });
}