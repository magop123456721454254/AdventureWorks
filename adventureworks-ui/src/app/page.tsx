// src/app/products/page.tsx
'use client';

import { useEffect, useState } from 'react';
import { Person } from './Models/PersonModel';

export default function PersonsPage() {
  const [persons, setPersons] = useState<Person[]>([]);

  useEffect(() => {
    fetch('http://localhost:5201/api/person/500') // .NET API
      .then((res) => res.json())
      .then((data) => setPersons(data));
  }, []);

   return (
    <div className="p-3 content-center">
      <table className="w-3/4 border border-gray-200">
        <thead className="bg-sky-600">
          <tr>
            <th className="py-2 px-4 text-left border-b">ID</th>
            <th className="py-2 px-4 text-left border-b">Title</th>
            <th className="py-2 px-4 text-left border-b">First Name</th>
            <th className="py-2 px-4 text-left border-b">Last Name</th>
            <th className="py-2 px-4 text-left border-b">Suffix</th>
          </tr>
        </thead>
        <tbody>
          {persons.map((p) => (
            <tr key={p.businessEntityId} className="hover:bg-sky-800">
              <td className="py-2 px-4 border-b">{p.businessEntityId}</td>
              <td className="py-2 px-4 border-b">{p.title}</td>
              <td className="py-2 px-4 border-b">{p.firstName}</td>
              <td className="py-2 px-4 border-b">{p.lastName}</td>
              <td className="py-2 px-4 border-b">{p.suffix}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}