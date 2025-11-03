# LogisticsCorp - UI Pages Specification

This document outlines all UI pages required to implement the LogisticsCorp web application based on the project specification (CSCB532_Kostadinova_Logistic_Company.pdf).

---

## 1. Public Pages (No Authentication Required)

### 1.1 Login Page
**Route:** `/login`
**Purpose:** User authentication entry point
**Features:**
- Email/username input
- Password input
- "Remember me" checkbox
- Login button
- Link to registration page
- Forgot password link (optional)

### 1.2 Register Page
**Route:** `/register`
**Purpose:** New client registration
**Features:**
- Personal information form (name, email, phone, address)
- Password and confirm password fields
- Terms and conditions acceptance
- Register button
- Link back to login page
**Note:** Creates users with CLIENT role by default

---

## 2. Admin Pages

### 2.1 Admin Dashboard
**Route:** `/admin/dashboard`
**Purpose:** Overview of system statistics and key metrics
**Features:**
- Total shipments count (today, this week, this month)
- Total revenue statistics
- Active employees count
- Active clients count
- Recent shipments summary
- Pending shipments count
- Quick action buttons

### 2.2 Company Settings
**Route:** `/admin/company`
**Purpose:** Manage logistics company information
**Features:**
- Company name, logo, contact information
- Business registration details
- Operating hours
- General settings
- Edit and save functionality

### 2.3 Employee Management

#### 2.3.1 Employee List
**Route:** `/admin/employees`
**Purpose:** View all employees in the company (Report 5a)
**Features:**
- Searchable/filterable table of all employees
- Columns: Name, Email, Phone, Employee Type (Courier/Office Staff), Office, Status, Actions
- Pagination
- Filter by: Employee Type, Office, Active/Inactive status
- Sort by various columns
- Add new employee button
- Export to CSV/Excel

#### 2.3.2 Create Employee
**Route:** `/admin/employees/create`
**Purpose:** Add new employee to the system
**Features:**
- Personal information form (first name, last name, email, phone)
- Employee type selection (Courier/Office Staff)
- Office assignment dropdown
- User account creation (email, initial password)
- Role assignment (EMPLOYEE)
- Status (Active/Inactive)
- Save button

#### 2.3.3 Edit Employee
**Route:** `/admin/employees/edit/{id}`
**Purpose:** Modify existing employee information
**Features:**
- Pre-filled form with current employee data
- All fields from create form
- Change office assignment
- Change employee type
- Deactivate/Activate employee
- Update button
- Delete button (with confirmation)

#### 2.3.4 Employee Details
**Route:** `/admin/employees/view/{id}`
**Purpose:** View detailed employee information
**Features:**
- Full employee profile
- Associated user account details
- Assigned office information
- Shipments registered by this employee (Report 5d)
- Activity history
- Edit and delete buttons

### 2.4 Client Management

#### 2.4.1 Client List
**Route:** `/admin/clients`
**Purpose:** View all clients of the company (Report 5b)
**Features:**
- Searchable/filterable table of all clients
- Columns: Name, Email, Phone, Address, Registration Date, Status, Actions
- Pagination
- Filter by: Active/Inactive status, Registration date
- Sort by various columns
- Add new client button (optional - clients usually self-register)
- Export to CSV/Excel

#### 2.4.2 Create Client
**Route:** `/admin/clients/create`
**Purpose:** Admin creates client account (alternative to self-registration)
**Features:**
- Personal information form (first name, last name, email, phone)
- Address information (street, city, postal code, country)
- User account creation (email, initial password)
- Role assignment (CLIENT)
- Status (Active/Inactive)
- Save button

#### 2.4.3 Edit Client
**Route:** `/admin/clients/edit/{id}`
**Purpose:** Modify existing client information
**Features:**
- Pre-filled form with current client data
- All fields from create form
- Deactivate/Activate client
- Update button
- Delete button (with confirmation)

#### 2.4.4 Client Details
**Route:** `/admin/clients/view/{id}`
**Purpose:** View detailed client information
**Features:**
- Full client profile
- Associated user account details
- Shipments sent by this client (Report 5f)
- Shipments received by this client (Report 5g)
- Total spending statistics
- Activity history
- Edit and delete buttons

### 2.5 Office Management

#### 2.5.1 Office List
**Route:** `/admin/offices`
**Purpose:** View all company offices
**Features:**
- Table of all offices
- Columns: Office Name, Address, City, Phone, Manager, Employees Count, Status, Actions
- Add new office button
- Edit and delete actions
- View employees assigned to each office

#### 2.5.2 Create Office
**Route:** `/admin/offices/create`
**Purpose:** Add new office location
**Features:**
- Office name
- Address information (street, city, postal code, country)
- Contact phone
- Operating hours
- Manager assignment (optional)
- Status (Active/Inactive)
- Save button

#### 2.5.3 Edit Office
**Route:** `/admin/offices/edit/{id}`
**Purpose:** Modify existing office information
**Features:**
- Pre-filled form with current office data
- All fields from create form
- Update button
- Delete button (with confirmation)

#### 2.5.4 Office Details
**Route:** `/admin/offices/view/{id}`
**Purpose:** View detailed office information
**Features:**
- Full office details
- List of employees assigned to this office
- Shipments processed at this office
- Statistics (shipments processed, revenue)
- Edit and delete buttons

### 2.6 Pricing Rules Management

#### 2.6.1 Pricing Rules List
**Route:** `/admin/pricing-rules`
**Purpose:** Manage weight-based pricing rules
**Features:**
- Table of all pricing rules
- Columns: Min Weight, Max Weight, Price to Office, Price to Address, Actions
- Add new rule button
- Edit and delete actions
- Sort by weight ranges

#### 2.6.2 Create Pricing Rule
**Route:** `/admin/pricing-rules/create`
**Purpose:** Add new pricing rule
**Features:**
- Minimum weight (kg)
- Maximum weight (kg)
- Price for delivery to office
- Price for delivery to address
- Effective date (optional)
- Save button

#### 2.6.3 Edit Pricing Rule
**Route:** `/admin/pricing-rules/edit/{id}`
**Purpose:** Modify existing pricing rule
**Features:**
- Pre-filled form with current rule data
- All fields from create form
- Update button
- Delete button (with confirmation)

### 2.7 User Role Management
**Route:** `/admin/users/roles`
**Purpose:** Assign and manage user roles
**Features:**
- List of all users
- Current role display
- Role assignment dropdown (EMPLOYEE, CLIENT, ADMIN)
- Change role functionality (Requirement 2)
- Filter by role
- Search users

### 2.8 Reports

#### 2.8.1 Reports Dashboard
**Route:** `/admin/reports`
**Purpose:** Central hub for all reports
**Features:**
- Links to all available reports
- Quick date range selector
- Export options

#### 2.8.2 All Shipments Report
**Route:** `/admin/reports/shipments/all`
**Purpose:** View all registered shipments (Report 5c)
**Features:**
- Comprehensive shipment list
- Filters: Date range, status, sender, recipient, office
- Columns: Tracking ID, Sender, Recipient, Delivery Address, Weight, Price, Status, Registration Date, Registered By
- Pagination
- Export to CSV/Excel
- Print view

#### 2.8.3 Shipments by Employee Report
**Route:** `/admin/reports/shipments/by-employee`
**Purpose:** View all shipments registered by a specific employee (Report 5d)
**Features:**
- Employee selector dropdown
- Shipment list filtered by selected employee
- Same columns as All Shipments Report
- Date range filter
- Statistics: Total shipments registered, total revenue
- Export functionality

#### 2.8.4 Undelivered Shipments Report
**Route:** `/admin/reports/shipments/undelivered`
**Purpose:** View all sent but not yet received shipments (Report 5e)
**Features:**
- List of shipments with status != "Delivered"
- Columns: Tracking ID, Sender, Recipient, Delivery Address, Current Status, Days in Transit, Registered By
- Sort by: Days in transit, registration date
- Highlight overdue shipments
- Export functionality

#### 2.8.5 Client Shipments Report
**Route:** `/admin/reports/shipments/by-client`
**Purpose:** View shipments sent and received by specific client (Reports 5f, 5g)
**Features:**
- Client selector dropdown
- Two tabs: "Sent by Client" (Report 5f) and "Received by Client" (Report 5g)
- Shipment lists for each tab
- Date range filter
- Statistics: Total shipments, total spent/saved
- Export functionality

#### 2.8.6 Revenue Report
**Route:** `/admin/reports/revenue`
**Purpose:** View company revenue for specific period (Report 5h)
**Features:**
- Date range selector (from date, to date)
- Predefined periods: Today, This Week, This Month, This Quarter, This Year, Custom
- Revenue summary: Total revenue, number of shipments, average shipment value
- Revenue breakdown: By office, by employee, by delivery type (office vs address)
- Revenue chart/graph visualization
- Detailed transaction list
- Export to CSV/Excel
- Print view

---

## 3. Employee Pages

### 3.1 Employee Dashboard
**Route:** `/employee/dashboard`
**Purpose:** Overview for employee users
**Features:**
- Shipments registered today count
- Active shipments count
- Personal statistics (shipments registered this week/month)
- Recent shipments registered by this employee
- Quick action: Register new shipment
- Pending deliveries (for couriers)
- Notifications

### 3.2 Shipment Management

#### 3.2.1 All Shipments List
**Route:** `/employee/shipments`
**Purpose:** View all shipments in the system (Requirement 6)
**Features:**
- Comprehensive searchable/filterable table
- Columns: Tracking ID, Sender, Recipient, Delivery Address, Weight, Price, Status, Registration Date, Actions
- Filters: Status, date range, delivery type, office
- Advanced search: By tracking number, sender name, recipient name
- Pagination
- Quick view button for shipment details
- Edit button (for certain statuses)
- Status update button

#### 3.2.2 Register New Shipment
**Route:** `/employee/shipments/create`
**Purpose:** Register new sent/received shipment (Requirement 4)
**Features:**
- **Sender Information:**
  - Client search/select (existing client) or manual entry (new sender)
  - Name, phone, email
- **Recipient Information:**
  - Client search/select (existing client) or manual entry
  - Name, phone, email
- **Shipment Details:**
  - Delivery address (street, city, postal code) OR office selection
  - Weight (kg)
  - Delivery type: To Office / To Address
  - Automatic price calculation based on weight and delivery type
  - Description/notes
  - Fragile item checkbox
  - Insurance option
- **Registration Details:**
  - Registration office (auto-filled with employee's office)
  - Registration date/time (auto-filled)
- Save button
- Generate tracking number upon creation
- Print receipt option

#### 3.2.3 Edit Shipment
**Route:** `/employee/shipments/edit/{id}`
**Purpose:** Modify shipment information
**Features:**
- Pre-filled form with current shipment data
- Allow updates based on current status
- Update status
- Add notes/comments
- Update button
**Restrictions:** Some fields locked based on shipment status

#### 3.2.4 Shipment Details
**Route:** `/employee/shipments/view/{id}`
**Purpose:** View complete shipment information and history
**Features:**
- Full shipment details (all fields)
- Sender and recipient information
- Pricing breakdown
- Current status with status badge
- Shipment history timeline (all status changes)
- Registered by employee information
- Documents/receipts
- Edit button
- Update status button
- Print shipment label
- Print receipt

#### 3.2.5 Update Shipment Status
**Route:** `/employee/shipments/status/{id}` (Modal or inline)
**Purpose:** Update shipment status (Requirement 4 - register sent/received)
**Features:**
- Current status display
- Status dropdown: Registered, In Transit, Out for Delivery, Delivered, Returned, Cancelled
- Status update timestamp (auto)
- Notes/comments field
- Location update (current office/address)
- Update by employee (auto-filled)
- Save button
- Creates entry in ShipmentHistory

### 3.3 Employee Reports Access

#### 3.3.1 My Registered Shipments
**Route:** `/employee/my-shipments`
**Purpose:** View shipments registered by logged-in employee
**Features:**
- Filtered list of shipments registered by current employee
- Same features as All Shipments List
- Personal statistics

#### 3.3.2 Reports Access
**Route:** `/employee/reports`
**Purpose:** Access to employee-visible reports
**Features:**
- All Shipments Report (same as admin)
- Shipments by Employee Report (can view own and others)
- Undelivered Shipments Report
- Client Shipments Report (lookup any client)

### 3.4 Client Lookup
**Route:** `/employee/clients`
**Purpose:** Search and view client information
**Features:**
- Search clients by name, email, phone
- View client details
- View client's shipments (sent and received)
- Contact information
**Note:** Read-only for employees; no edit capability

---

## 4. Client Pages

### 4.1 Client Dashboard
**Route:** `/client/dashboard`
**Purpose:** Overview for client users
**Features:**
- Active shipments count (in transit)
- Total shipments sent/received
- Recent shipments (last 5-10)
- Quick track shipment search
- Notifications about shipment status updates
- Quick action: Request new shipment

### 4.2 My Shipments

#### 4.2.1 My Shipments List
**Route:** `/client/shipments`
**Purpose:** View shipments sent or received by logged-in client (Requirement 7)
**Features:**
- Two tabs: "Sent by Me" and "Received by Me"
- Searchable/filterable table
- Columns: Tracking ID, Other Party (Sender/Recipient), Delivery Address, Weight, Price, Status, Date
- Filter by: Status, date range
- Quick track button
- View details button
**Note:** Shows ONLY shipments where client is sender OR recipient

#### 4.2.2 Shipment Details (Client View)
**Route:** `/client/shipments/view/{id}`
**Purpose:** View shipment details (read-only for clients)
**Features:**
- Full shipment information
- Sender and recipient details
- Delivery address
- Current status with visual indicator
- Estimated delivery date
- Tracking history timeline
- Price and payment information
- Download/print receipt
**Restriction:** Client can only view their own shipments

### 4.3 Track Shipment
**Route:** `/client/track`
**Purpose:** Track shipment by tracking number
**Features:**
- Tracking number input field
- Track button
- Display shipment status and history
- Visual timeline of shipment journey
- Estimated delivery date
- Current location
**Note:** Client can track any shipment by tracking number (public tracking)

### 4.4 Shipment History
**Route:** `/client/history`
**Purpose:** View complete history of all past shipments
**Features:**
- List of all completed/delivered shipments
- Filters: Date range, sent vs received
- Search by tracking number
- Export personal shipping history
- Statistics: Total shipments, total spent

### 4.5 Request New Shipment
**Route:** `/client/shipments/request`
**Purpose:** Client requests a new shipment (optional feature)
**Features:**
- Recipient information form
- Delivery address or office selection
- Package details (estimated weight, description)
- Preferred pickup date/time
- Special instructions
- Submit request button
**Note:** Creates shipment request that employee must approve/complete

---

## 5. Common Pages (All Authenticated Users)

### 5.1 Profile Management
**Route:** `/profile`
**Purpose:** View and edit personal profile information
**Features:**
- View current user information
- Edit personal details (name, phone, address)
- Change password
- Email notification preferences
- Save changes button

### 5.2 Settings
**Route:** `/settings`
**Purpose:** User preferences and settings
**Features:**
- Account settings
- Notification preferences (email, SMS)
- Language selection (if multi-language support)
- Theme preferences (dark/light mode)
- Privacy settings

### 5.3 Notifications
**Route:** `/notifications`
**Purpose:** View all user notifications
**Features:**
- List of all notifications
- Mark as read/unread
- Filter by: Read/Unread, Date, Type
- Clear all notifications
- Notification types: Shipment status updates, system announcements, etc.

### 5.4 Help/Support
**Route:** `/help`
**Purpose:** Help documentation and support
**Features:**
- FAQ section
- User guides based on role
- Contact support form
- How-to videos/tutorials
- Glossary of terms

### 5.5 Not Found (404)
**Route:** `/not-found` or any invalid route
**Purpose:** Handle invalid routes gracefully
**Features:**
- Friendly 404 message
- Navigation back to home/dashboard
- Search functionality
- Common links

### 5.6 Unauthorized (403)
**Route:** `/unauthorized`
**Purpose:** Handle unauthorized access attempts
**Features:**
- Access denied message
- Explanation of required permissions
- Link back to appropriate dashboard
- Contact admin option

---

## 6. Shared Components/Layouts

### 6.1 Main Layout
**Features:**
- Top navigation bar with logo
- User menu (profile, settings, logout)
- Sidebar navigation (role-based menu)
- Breadcrumb navigation
- Page title and subtitle display (via PageStateService)
- Footer with copyright and links
- Responsive hamburger menu for mobile

### 6.2 Navigation Menu Items (Role-Based)

#### Admin Menu:
- Dashboard
- Employees
- Clients
- Offices
- Pricing Rules
- Shipments
- Reports
- Users & Roles
- Company Settings

#### Employee Menu:
- Dashboard
- All Shipments
- Register Shipment
- My Registered Shipments
- Reports
- Clients

#### Client Menu:
- Dashboard
- My Shipments
- Track Shipment
- History
- Request Shipment (optional)

---

## 7. Summary by Role

### Pages Count:
- **Public:** 2 pages
- **Admin:** 25+ pages
- **Employee:** 10+ pages
- **Client:** 6+ pages
- **Common:** 6 pages

### Total Estimated Pages: **49+ unique pages/views**

---

## 8. Implementation Priority

### Phase 1 - Core Functionality:
1. Authentication (Login, Register)
2. Admin: Employee Management (List, Create, Edit)
3. Admin: Client Management (List, Create, Edit)
4. Admin: Office Management (List, Create, Edit)
5. Employee: Shipment Management (List, Create, Edit, Update Status)
6. Client: My Shipments (List, View)

### Phase 2 - Reports & Analytics:
1. All required reports (5a-5h)
2. Admin Dashboard with statistics
3. Employee Dashboard
4. Client Dashboard
5. Revenue Report

### Phase 3 - Advanced Features:
1. Client Track Shipment
2. Shipment History timeline
3. Advanced search and filters
4. Export functionality
5. Print receipts and labels

### Phase 4 - Polish & UX:
1. Notifications system
2. Profile management
3. Settings pages
4. Help/Support
5. Mobile responsiveness optimization
6. Dark mode (following demo design)

---

## Notes:
- All pages must be responsive (mobile-friendly) as per specification
- Design should follow the dark theme with yellow accent (#FFD700) from the demo folder
- Use MudBlazor components for consistency
- Extend `ExtendedComponentBase` for all pages
- Set page titles using `PageStateService.SetPageInfo()`
- All employee pages show ALL shipments (Requirement 6)
- All client pages show ONLY their own shipments (Requirement 7)
- Status updates create entries in ShipmentHistory table
- Price calculated automatically based on weight and delivery type (office vs address)
