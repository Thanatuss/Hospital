# Doctor Appointment Booking API

This is a backend project built with ASP.NET Core for managing doctor appointments. It handles user registration/login, doctor availability, booking appointments, and some admin features like reporting.

---

## Features

- JWT authentication (roles: Admin, Doctor, Patient)
- Doctors can define available time slots
- Patients can browse and book time slots
- Admins can see basic reports (most active doctors, top specialties)
- Email notifications for booking or cancellation
- Simple search/filter for doctors based on specialty and location

---

## Roles & Permissions

| Role     | Can do                                                                 |
|----------|------------------------------------------------------------------------|
| Admin    | View reports, manage specialties and users                             |
| Doctor   | Create time slots, see bookings                                        |
| Patient  | View doctors, book appointments, cancel own bookings                   |

---

## Project Structure

The code is organized into layers:

- `Domain` – entity models and interfaces
- `Application` – services, DTOs, and business logic
- `Infrastructure` – database context, repositories, email service
- `WebApi` – controllers and request pipeline

---

## Main Entities

- **User**: basic user info and role
- **DoctorProfile**: additional info about doctors (specialty, location, bio)
- **Specialty**: medical field (e.g. Cardiology, Pediatrics)
- **TimeSlot**: doctor’s available time window
- **Appointment**: link between patient and timeslot

---

## Endpoints (some examples)

