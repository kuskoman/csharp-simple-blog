/** Generate by swagger-axios-codegen */
// @ts-nocheck
/* eslint-disable */

/** Generate by swagger-axios-codegen */
/* eslint-disable */
// @ts-nocheck
import axiosStatic, { AxiosInstance, AxiosRequestConfig } from 'axios';

import { Expose, Transform, Type, plainToClass } from 'class-transformer';

export interface IRequestOptions extends AxiosRequestConfig {
  /** only in axios interceptor config*/
  loading?: boolean;
  showError?: boolean;
}

export interface IRequestConfig {
  method?: any;
  headers?: any;
  url?: any;
  data?: any;
  params?: any;
}

// Add options interface
export interface ServiceOptions {
  axios?: AxiosInstance;
  /** only in axios interceptor config*/
  loading: boolean;
  showError: boolean;
}

// Add default options
export const serviceOptions: ServiceOptions = {};

// Instance selector
export function axios(configs: IRequestConfig, resolve: (p: any) => void, reject: (p: any) => void): Promise<any> {
  if (serviceOptions.axios) {
    return serviceOptions.axios
      .request(configs)
      .then(res => {
        resolve(res.data);
      })
      .catch(err => {
        reject(err);
      });
  } else {
    throw new Error('please inject yourself instance like axios  ');
  }
}

export function getConfigs(method: string, contentType: string, url: string, options: any): IRequestConfig {
  const configs: IRequestConfig = {
    loading: serviceOptions.loading,
    showError: serviceOptions.showError,
    ...options,
    method,
    url
  };
  configs.headers = {
    ...options.headers,
    'Content-Type': contentType
  };
  return configs;
}

export const basePath = '';

export interface IList<T> extends Array<T> {}
export interface List<T> extends Array<T> {}
export interface IDictionary<TValue> {
  [key: string]: TValue;
}
export interface Dictionary<TValue> extends IDictionary<TValue> {}

export interface IListResult<T> {
  items?: T[];
}

export class ListResultDto<T> implements IListResult<T> {
  items?: T[];
}

export interface IPagedResult<T> extends IListResult<T> {
  totalCount?: number;
  items?: T[];
}

export class PagedResultDto<T = any> implements IPagedResult<T> {
  totalCount?: number;
  items?: T[];
}

// customer definition
// empty

export class IdentityError {
  /**  */
  @Expose()
  'code'?: string;

  /**  */
  @Expose()
  'description'?: string;

  constructor(data: undefined | any = {}) {
    this['code'] = data['code'];
    this['description'] = data['description'];
  }
}

export class IdentityResult {
  /**  */
  @Expose()
  'succeeded'?: boolean;

  /**  */
  @Expose()
  'errors'?: object[];

  constructor(data: undefined | any = {}) {
    this['succeeded'] = data['succeeded'];
    this['errors'] = data['errors'];
  }
}

export class User {
  /**  */
  @Expose()
  'id'?: number;

  /**  */
  @Expose()
  'userName'?: string;

  /**  */
  @Expose()
  'normalizedUserName'?: string;

  /**  */
  @Expose()
  'email'?: string;

  /**  */
  @Expose()
  'normalizedEmail'?: string;

  /**  */
  @Expose()
  'emailConfirmed'?: boolean;

  /**  */
  @Expose()
  'passwordHash'?: string;

  /**  */
  @Expose()
  'securityStamp'?: string;

  /**  */
  @Expose()
  'concurrencyStamp'?: string;

  /**  */
  @Expose()
  'phoneNumber'?: string;

  /**  */
  @Expose()
  'phoneNumberConfirmed'?: boolean;

  /**  */
  @Expose()
  'twoFactorEnabled'?: boolean;

  /**  */
  @Expose()
  @Type(() => Date)
  'lockoutEnd'?: Date;

  /**  */
  @Expose()
  'lockoutEnabled'?: boolean;

  /**  */
  @Expose()
  'accessFailedCount'?: number;

  /**  */
  @Expose()
  'name'?: string;

  /**  */
  @Expose()
  'passwordDigest'?: string;

  constructor(data: undefined | any = {}) {
    this['id'] = data['id'];
    this['userName'] = data['userName'];
    this['normalizedUserName'] = data['normalizedUserName'];
    this['email'] = data['email'];
    this['normalizedEmail'] = data['normalizedEmail'];
    this['emailConfirmed'] = data['emailConfirmed'];
    this['passwordHash'] = data['passwordHash'];
    this['securityStamp'] = data['securityStamp'];
    this['concurrencyStamp'] = data['concurrencyStamp'];
    this['phoneNumber'] = data['phoneNumber'];
    this['phoneNumberConfirmed'] = data['phoneNumberConfirmed'];
    this['twoFactorEnabled'] = data['twoFactorEnabled'];
    this['lockoutEnd'] = data['lockoutEnd'];
    this['lockoutEnabled'] = data['lockoutEnabled'];
    this['accessFailedCount'] = data['accessFailedCount'];
    this['name'] = data['name'];
    this['passwordDigest'] = data['passwordDigest'];
  }
}

export class UserCreateDto {
  /**  */
  @Expose()
  'name': string;

  /**  */
  @Expose()
  'email': string;

  /**  */
  @Expose()
  'password': string;

  constructor(data: undefined | any = {}) {
    this['name'] = data['name'];
    this['email'] = data['email'];
    this['password'] = data['password'];
  }
}

export class UserLoginDto {
  /**  */
  @Expose()
  'email': string;

  /**  */
  @Expose()
  'password': string;

  constructor(data: undefined | any = {}) {
    this['email'] = data['email'];
    this['password'] = data['password'];
  }
}

export class UserResponseDto {
  /**  */
  @Expose()
  'email'?: string;

  /**  */
  @Expose()
  'name'?: string;

  /**  */
  @Expose()
  'id'?: number;

  constructor(data: undefined | any = {}) {
    this['email'] = data['email'];
    this['name'] = data['name'];
    this['id'] = data['id'];
  }
}
