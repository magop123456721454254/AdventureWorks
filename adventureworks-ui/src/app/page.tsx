/* eslint-disable @typescript-eslint/no-explicit-any */
'use client';
import { useQuery } from '@apollo/client';
import { GET_PERSONS_LIST_NO_PARAMETER } from './functions/queries/personQueries';
import { Person } from '@/app/models/personModel';

export default function PersonsPage() {
  const { data, loading, error, fetchMore } = useQuery(GET_PERSONS_LIST_NO_PARAMETER, {
    variables: { amount: 5, after: null }, // <-- pass your params here
  });


  if (loading) return <html><body><p>Loading...</p></body></html>;
  if (error) return <html><body><p>Error: {error.message}</p></body></html>;

  const nodes = data.personsList.edges.map((edge: any) => edge.node);
  
  return (
    <html>
      <body>
        <ul>
          {nodes.map((person: Person) => (
            <li key={person.businessEntityId}>
              {person.title} {person.firstName} {person.personType}
            </li>
          ))}
        </ul>
      </body>
    </html>
  );
}
