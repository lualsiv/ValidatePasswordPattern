# ValidatePasswordPattern

/*
 *Password attribute
 *
 * Data Annotations to Validate a Password.
 *
 *
 * Call in your Class:
 * [Password(ErrorMessage="Invalid Password.",PasswordMinLength=9,PasswordMaxLength=9,StrongPasswordRequired=true/false,SpecialRequiredCharacter=true/false)]
 *
 * ->PasswordMinLength = integer with the minimum size required for the password (Default = 6)
 * -> PasswordMaxLength = integer with the maximum size required for password (Default = 12)
 * -> StrongPasswordRequired = boolean (true/false) (Default=true) If informed with (true)
 * it is mandatory to type at least one uppercase, one lowercase and a number
 * ->RequiredSpecialCharacter = boolean (true/false) (Default=true) If informed with (true) and StrongPasswordRequired = (true)
 * it is mandatory to type at least one special character !@#$%^&*()-+
 *
 */

Using swagger to test api calls