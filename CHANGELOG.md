# Change Log
All notable changes to this project will be documented in this file.

## [1.8.4] - 2021-02-05
### Fixed
- Bugfix in user agent generation

## [1.8.3] - 2020-12-02
### Added
- Added possibility of using custom user agent in construction

## [1.8.2] - 2020-10-21
### Added
- Typo update

## [1.8.1] - 2020-10-21
### Added
- ExtraPriceWildcard added
- ExtraPrice added

## [1.8.0] - 2020-10-21
### Added
- DateSubscriptionExpired added

## [1.7.0] - 2020-03-13
### Fixed
- Update RestSharp to 106.10.1 for TLS1.2

## [1.6.2] - 2020-02-25
### Fixed
- Resolved issue #2

## [1.5.0] - 2017-03-22
### Added
- Compatability with Xolphin REST Api v1.5.0
- Mode for testing with our test environment
- Certificate Requests: If there are open request notes for the customer, a new field 'requiresAction' will be set in the CertificateRequest object
- Certificate Requests: You can now send a language parameter with the request, which will be used for (eg) the Subscriber Agreement
- Certificate Requests: A new field 'brandValidation' is added, which is used to indicate if the request is being held for review due to specific brand names
