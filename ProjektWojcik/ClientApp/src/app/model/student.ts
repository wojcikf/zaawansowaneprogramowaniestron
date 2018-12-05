export class Student {
  public id: number;
  public FirstName: string;
  public LastName: string;
  public Grant: number;

  constructor(id: number = 0, firstName: string = "", lastName: string = "", grant: number = 0) {
    this.id = id
    this.FirstName = firstName;
    this.LastName = lastName;
    this.Grant = grant;
  }
}
