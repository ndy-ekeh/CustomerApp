export class Customer {
    firstName = "";
    lastName = "";
    accountNumber = "";
    houseAddress = "";
    phoneNo = "";
    email = "";
    customerCode?: number;
    id?: number;

}

/**
 * Represents the response for Each API call
 */
export interface CommonResponse {
    code: string;
    description: string;
}
