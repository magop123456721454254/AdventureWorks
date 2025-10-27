// src/app/products/page.tsx
'use client';

import { useEffect, useState } from 'react';
import { Person } from './Models/PersonModel';

export default function PersonsPage() {
  const [persons, setPersons] = useState<Person[]>([]);
  const apiUrl = process.env.NEXT_PUBLIC_API_URL || "http://localhost:5000";
  fetch(`${apiUrl}/api/Person/GetPersonsList/`);

  useEffect(() => {
    fetch(`${apiUrl}/api/Person/GetPersonsList/`)
      .then((res) => res.json())
      .then((data) => setPersons(data));
  }, [apiUrl]);

  // useEffect(() => {
  //   fetch(`${process.env.NEXT_PUBLIC_API_URL}/api/person/`)
  //     .then((res) => res.json())
  //     .then((data) => setPersons(data));
  // }, []);

  // TEST COMMENT FOR FIRST PR
  return (
    <div className="p-3 content-center">
      <table className="w-3/4 border border-gray-200">
        <thead className="bg-sky-600">
          <tr>
            <th className="py-2 px-4 text-left border-b">ID</th>
            <th className="py-2 px-4 text-left border-b">Title</th>
            <th className="py-2 px-4 text-left border-b">First Nssssame</th>
            <th className="py-2 px-4 text-left border-b">Middle Name</th>
            <th className="py-2 px-4 text-left border-b">Last Name</th>
          </tr>
        </thead>
        <tbody>
          {persons.map((p) => (
            <tr key={p.businessEntityId} className="hover:bg-sky-800">
              <td className="py-2 px-4 border-b">{p.businessEntityId}</td>
              <td className="py-2 px-4 border-b">{p.title}</td>
              <td className="py-2 px-4 border-b">{p.firstName}</td>
              <td className="py-2 px-4 border-b">{p.middleName}</td>
              <td className="py-2 px-4 border-b">{p.lastName}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}